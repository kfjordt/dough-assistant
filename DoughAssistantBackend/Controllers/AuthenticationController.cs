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

        [HttpPost("SessionCookie")]
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
                var userCreated = _userRepository.CreateUser(newUser);
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

        [HttpPost("RememberMeCookie")]
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

        [HttpPost("RememberMeCookieValidation")]
        public IActionResult ValidateToken([FromBody] RememberMeTokenDto rememberMeTokenDto)
        {
            RememberMeToken? rememberMeToken =
                _authenticationRepository.GetRememberMeTokenById(rememberMeTokenDto.RememberMeTokenId);

            if (rememberMeToken == null)
            {
                return BadRequest("Token does not exist.");
            }

            bool isTokenValid = _authenticationService.ValidateToken(rememberMeTokenDto, rememberMeToken);
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
            
            Response.Cookies.Append("RememberMeId", renewedToken.RememberMeTokenId, cookieOptions);
            Response.Cookies.Append("RememberMeToken", renewedToken.Token, cookieOptions);
            
            return Ok();
        }
    }
}