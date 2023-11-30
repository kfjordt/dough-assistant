using DoughAssistantBackend.Dto;
using Microsoft.AspNetCore.Mvc;
using Google.Apis.Auth;
using DoughAssistantBackend.Models;
using AutoMapper;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Repository;
using DoughAssistantBackend.Services;
using DoughAssistantBackend.Properties;
using Newtonsoft.Json.Linq;
using System.Web;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationService _authenticationService;
        private readonly GoogleService _googleService;

        public AuthenticationController(IAuthenticationRepository authenticationRepository,
            IUserRepository userRepository, AuthenticationService authenticationService, IMapper mapper,
            GoogleService googleService)
        {
            _authenticationRepository = authenticationRepository;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
            _googleService = googleService;
        }

        [HttpGet("IsSessionCookieValid")]
        public IActionResult IsSessionCookieValid()
        {
            var sessionKey = HttpContext.Request.Cookies["SessionKey"];

            if (sessionKey == null)
            {
                return BadRequest("User does not have session token");
            }
            
            bool sessionExists = _authenticationRepository.SessionExists(sessionKey);
            return Ok(sessionExists);
        }

        [HttpGet("GetLoggedInUserIdFromSessionCookie")]
        public IActionResult GetLoggedInUserIdFromSessionCookie()
        {
            string? sessionKey = HttpContext.Request.Cookies["SessionKey"];

            if (sessionKey == null)
            {
                return BadRequest("Session key not found");
            }
            
            User? userLookup = _authenticationRepository.GetUserBySessionId(sessionKey);

            if (userLookup == null)
            {
                return BadRequest("User not found");
            }

            return Ok(userLookup.UserId);
        }
        
        [HttpGet("GetLoggedInUserIdFromRememberMeCookie")]
        public IActionResult GetLoggedInUserIdFromRememberMeCookie()
        {
            string? rememberMeCookieId = HttpContext.Request.Cookies["RememberMeId"];
            if (rememberMeCookieId == null)
            {
                return BadRequest("Remember me token not found");
            }
            
            RememberMeToken? rememberMeTokenLookup = _authenticationRepository.GetRememberMeTokenById(rememberMeCookieId);
            if (rememberMeTokenLookup == null)
            {
                return BadRequest("Token not found");
            }

            return Ok(rememberMeTokenLookup.UserId);
        }
        
        [HttpPost("GetSessionCookie")]
        public async Task<IActionResult> RequestSessionAsync([FromQuery] string googleJwt)
        {
            UserDto user;
            try
            {
                user = await _googleService.VerifyAccessTokenAndGetUser(googleJwt);
            }
            catch
            {
                return BadRequest("Invalid access token");
            }

            if (!_userRepository.UserExists(user.UserId))
            {
                var newUser = _mapper.Map<User>(user);
                _userRepository.CreateUser(newUser);
            }
            
            bool userAlreadyHasSession = _authenticationRepository.UserHasSession(user.UserId);
            
            string sessionKey;
            if (!userAlreadyHasSession)
            {
                SessionToken sessionToken = _authenticationService.GenerateNewSession(user.UserId);
            
                if (!_authenticationRepository.CreateSessionToken(sessionToken))
                {
                    ModelState.AddModelError("", "Something went wrong while saving session");
                    return StatusCode(500, ModelState);
                }
            
                sessionKey = sessionToken.SessionKey;
            }
            else
            {
                sessionKey = _authenticationRepository.GetSessionTokenByUserId(user.UserId).SessionKey;
            }
            
            Response.Cookies.Append("SessionKey", sessionKey, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None
            });
            
            return Ok(user.UserId);
        }

        [HttpPost("GetRememberMeCookie")]
        public IActionResult RequestRememberMeToken(string userId)
        {
            RememberMeToken rememberMeToken = _authenticationService.GenerateNewRememberMeToken(userId);
            _authenticationRepository.CreateRememberMeToken(rememberMeToken);

            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.Now.AddDays(30)
            };
            
            Response.Cookies.Append("RememberMeId", rememberMeToken.RememberMeTokenId, cookieOptions);
            Response.Cookies.Append("RememberMeToken", rememberMeToken.Token, cookieOptions);
            
            return Ok();
        }

        [HttpPost("IsRememberMeCookieValid")]
        public IActionResult ValidateToken()
        {
            var rememberMeCookieId = HttpContext.Request.Cookies["RememberMeId"];
            var rememberMeCookieToken = HttpContext.Request.Cookies["RememberMeToken"];

            if (rememberMeCookieId == null || rememberMeCookieToken == null)
            {
                return Ok(false);
            }
            
            RememberMeToken? rememberMeToken =
                _authenticationRepository.GetRememberMeTokenById(rememberMeCookieId);

            if (rememberMeToken == null)
            {
                return BadRequest("Token does not exist.");
            }

            bool isTokenValid = _authenticationService.ValidateToken(rememberMeCookieToken, rememberMeToken);
            if (!isTokenValid)
            {
                // Theft assumed
                _authenticationRepository.DeleteSessionsByUserId(rememberMeToken.UserId);
                return BadRequest(ModelState);
            }

            RememberMeToken renewedToken = _authenticationService.RenewToken(rememberMeToken);
            _authenticationRepository.UpdateToken(renewedToken);

            var cookieOptions = new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.Now.AddDays(30)
            };
            
            SessionToken sessionToken = _authenticationService.GenerateNewSession(rememberMeToken.UserId);
            
            if (!_authenticationRepository.CreateSessionToken(sessionToken))
            {
                ModelState.AddModelError("", "Something went wrong while saving session");
                return StatusCode(500, ModelState);
            }
            
            Response.Cookies.Append("SessionKey", sessionToken.SessionKey, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None
            });
            
            Response.Cookies.Append("RememberMeId", renewedToken.RememberMeTokenId, cookieOptions);
            Response.Cookies.Append("RememberMeToken", renewedToken.Token, cookieOptions);
            
            return Ok();
        }
    }
}