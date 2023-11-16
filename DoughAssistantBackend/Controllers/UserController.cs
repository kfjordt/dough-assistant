using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using Microsoft.AspNetCore.Authorization;
using DoughAssistantBackend.Services;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly UserService _userService;

        public UserController(IUserRepository userRepository, IMapper mapper, UserService userService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto userToCreate)
        {
            if (userToCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newUser = _userService.GenerateNewUser(userToCreate);

            if (!_userRepository.CreateUser(newUser))
            {
                ModelState.AddModelError("", "Something went wrong while saving user");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}