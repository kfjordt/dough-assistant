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

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserRepository _userRepository;
        private readonly SessionService _sessionService;
        private readonly UserService _userService;

        public SessionController(ISessionRepository sessionRepository, IUserRepository userRepository, SessionService sessionService, UserService userService)
        {
            _sessionRepository = sessionRepository;
            _userRepository = userRepository;
            _sessionService = sessionService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestSessionAsync([FromBody] UserDto userRequesting, [FromQuery] string googleAuthToken)
        {
            var backendSecrets = await JsonFileReader.ReadAsync<BackendSecrets>("./Properties/backendSecrets.json");

            var httpClient = new HttpClient();
            var tokenInfoEndpoint = $"https://www.googleapis.com/oauth2/v3/tokeninfo?access_token={googleAuthToken}";
            var response = await httpClient.GetStringAsync(tokenInfoEndpoint);

            JObject tokenInfo = JObject.Parse(response);

            if (!tokenInfo.TryGetValue("sub", out var sub))
            {
                return BadRequest("Invalid access token");
            }

            string userId = sub.ToString();
            if (!_userRepository.UserExists(userId))
            {
                var newUser = _userService.GenerateNewUser(userRequesting);
                _userRepository.CreateUser(newUser);
            }

            Session session = _sessionService.GenerateNewSession(userId);

            if (!_sessionRepository.CreateSession(session))
            {
                ModelState.AddModelError("", "Something went wrong while saving session");
                return StatusCode(500, ModelState);
            }

            Response.Cookies.Append("SessionKey", session.SessionKey, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
            });

            return Ok("Session succesfully created");
        }
    }
}
