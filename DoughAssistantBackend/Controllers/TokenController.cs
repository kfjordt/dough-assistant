using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DoughAssistantBackend.Services;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private readonly TokenService _tokenService;
        
        public TokenController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult GetToken(string name)
        {
            var tokenExpirationTime = TimeSpan.FromHours(24);
            var token = _tokenService.CreateNewToken(name, tokenExpirationTime);
            
            return Ok(token);
        }
    }
}