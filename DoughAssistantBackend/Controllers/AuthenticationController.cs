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
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AuthenticationService _authenticationService;
        private readonly GoogleService _googleService;

        public SessionController(ISessionRepository sessionRepository, IUserRepository userRepository, AuthenticationService authenticationService, IMapper mapper, GoogleService googleService)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _authenticationService = authenticationService;
            _mapper = mapper;
            _googleService = googleService;
        }

        [HttpGet]
        public async Task<IActionResult> RequestSessionAsync ([FromQuery] string googleJwt)
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

            bool userAlreadyHasSession = _sessionRepository.UserHasSession(user.UserId);

            string sessionKey;
            if (!userAlreadyHasSession)
            {
                SessionToken sessionToken = _authenticationService.GenerateNewSession(user.UserId);

                if (!_sessionRepository.CreateSession(sessionToken))
                {
                    ModelState.AddModelError("", "Something went wrong while saving session");
                    return StatusCode(500, ModelState);
                }

                sessionKey = sessionToken.SessionKey;
            }
            else
            {
                sessionKey = _sessionRepository.GetSessionByUserId(user.UserId).SessionKey;
            }

            Response.Cookies.Append("SessionKey", sessionKey, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                SameSite = SameSiteMode.None
            });

            return Ok(user.UserId);
        }

        [HttpGet]
        public IActionResult RequestRememberMeToken(string userId)
        {
            _authenticationService.
        }

        [HttpGet]
        public IActionResult IsTokenValid([FromBody] RememberMeTokenDto rememberMeTokenDto)
        {
            
        }
    }
}
