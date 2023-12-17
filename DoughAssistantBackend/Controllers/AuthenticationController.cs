using DoughAssistantBackend.Dto;
using Microsoft.AspNetCore.Mvc;
using DoughAssistantBackend.Models;
using AutoMapper;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Services;

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

        [HttpGet("ValidSessionCookieExists")]
        [ProducesResponseType(typeof(CookieValidationDto), 200)]
        public IActionResult ValidSessionCookieExists()
        {
            string sessionCookieId = HttpContext.Request.Cookies[AuthenticationService.CookieNames.SessionCookieId];
            string sessionCookieKey = HttpContext.Request.Cookies[AuthenticationService.CookieNames.SessionCookieKey];

            var cookieValidationDto = new CookieValidationDto()
            {
                UserExists = false
            };

            if (sessionCookieId == null || sessionCookieKey == null)
            {
                return Ok(cookieValidationDto);
            }

            AuthenticationToken sessionToken =
                _authenticationRepository.GetSessionTokenBySessionCookieId(sessionCookieId);

            bool isTokenValid = _authenticationService.ValidateToken(sessionCookieKey, sessionToken);
            if (!isTokenValid)
            {
                // Theft
                // TODO: Wipe user sessions from db
                return BadRequest("Token is invalid");
            }

            cookieValidationDto = new CookieValidationDto()
            {
                UserExists = true,
                UserId = sessionToken.UserId
            };

            return Ok(cookieValidationDto);
        }

        [HttpPost("ExchangeGoogleJwtForSessionCookie")]
        public async Task<IActionResult> ExchangeGoogleJwtForSessionCookie(string googleJwt)
        {
            var userDto = await _googleService.VerifyAccessTokenAndGetUser(googleJwt);
            var userExists = _userRepository.UserExists(userDto.UserId);

            if (!userExists)
            {
                User userToCreate = this._mapper.Map<User>(userDto);
                _userRepository.CreateUser(userToCreate);
            }

            var sessionToken = _authenticationService.GenerateAuthenticationToken(userDto.UserId);
            _authenticationRepository.CreateSessionToken(sessionToken);


            Response.Cookies.Append(
                AuthenticationService.CookieNames.SessionCookieId,
                sessionToken.Id,
                AuthenticationService.DefaultCookieOptions
            );

            Response.Cookies.Append(
                AuthenticationService.CookieNames.SessionCookieKey,
                sessionToken.Key,
                AuthenticationService.DefaultCookieOptions
            );

            return Ok();
        }

        [HttpGet("ValidRememberMeCookieExists")]
        [ProducesResponseType(typeof(CookieValidationDto), 200)]
        public IActionResult ValidRememberMeCookieExists()
        {
            string rememberMeCookieId =
                HttpContext.Request.Cookies[AuthenticationService.CookieNames.RememberMeCookieId];
            string rememberMeCookieKey =
                HttpContext.Request.Cookies[AuthenticationService.CookieNames.RememberMeCookieKey];

            var cookieValidationDto = new CookieValidationDto()
            {
                UserExists = false
            };

            if (rememberMeCookieId == null || rememberMeCookieKey == null)
            {
                return Ok(cookieValidationDto);
            }

            AuthenticationToken rememberMeToken =
                _authenticationRepository.GetRememberMeTokenByRememberMeCookieId(rememberMeCookieId);

            bool isTokenValid = _authenticationService.ValidateToken(rememberMeCookieKey, rememberMeToken);
            if (!isTokenValid)
            {
                // Theft
                // TODO: Wipe user sessions from db
                return BadRequest("Token is invalid");
            }

            cookieValidationDto = new CookieValidationDto()
            {
                UserExists = true,
                UserId = rememberMeToken.UserId
            };

            return Ok(cookieValidationDto);
        }

        [HttpPost("ConsumeRememberMeCookie")]
        public IActionResult ConsumeRememberMeCookie()
        {
            string rememberMeCookieId =
                HttpContext.Request.Cookies[AuthenticationService.CookieNames.RememberMeCookieId];
            string rememberMeCookieKey =
                HttpContext.Request.Cookies[AuthenticationService.CookieNames.RememberMeCookieKey];

            var cookieValidationDto = new CookieValidationDto()
            {
                UserExists = false
            };

            if (rememberMeCookieId == null || rememberMeCookieKey == null)
            {
                return Ok(cookieValidationDto);
            }

            AuthenticationToken rememberMeToken =
                _authenticationRepository.GetRememberMeTokenByRememberMeCookieId(rememberMeCookieId);

            bool isTokenValid = _authenticationService.ValidateToken(rememberMeCookieKey, rememberMeToken);
            if (!isTokenValid)
            {
                // Theft
                // TODO: Wipe user sessions from db
                return BadRequest("Token is invalid");
            }

            var renewedRememberMeToken = _authenticationService.RenewToken(rememberMeToken);
            _authenticationRepository.UpdateRememberMeToken(renewedRememberMeToken);

            var sessionToken = _authenticationService.GenerateAuthenticationToken(rememberMeToken.UserId);
            _authenticationRepository.CreateSessionToken(sessionToken);

            Response.Cookies.Append(
                AuthenticationService.CookieNames.SessionCookieId,
                sessionToken.Id,
                AuthenticationService.DefaultCookieOptions
            );

            Response.Cookies.Append(
                AuthenticationService.CookieNames.SessionCookieKey,
                sessionToken.Key,
                AuthenticationService.DefaultCookieOptions
            );
            
            Response.Cookies.Append(
                AuthenticationService.CookieNames.RememberMeCookieId,
                renewedRememberMeToken.Id,
                AuthenticationService.DefaultCookieOptions
            );

            Response.Cookies.Append(
                AuthenticationService.CookieNames.RememberMeCookieKey,
                renewedRememberMeToken.Key,
                AuthenticationService.DefaultCookieOptions
            );

            return Ok();
        }
    }
}