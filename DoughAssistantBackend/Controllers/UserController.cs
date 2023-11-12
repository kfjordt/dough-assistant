using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using Microsoft.AspNetCore.Authorization;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UserDto>>(_userRepository.GetUsers());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(users);
        }

        [HttpGet("{email}")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(string email)
        {
            if (!_userRepository.UserExists(email))
                return NotFound();

            var user = _mapper.Map<UserDto>(_userRepository.GetUser(email));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
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

            var userMap = _mapper.Map<User>(userToCreate);

            userMap.RegistrationDate = DateTime.UtcNow;

            if (!_userRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving user");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpDelete("{email}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(string email)
        {
            if (!_userRepository.UserExists(email))
            {
                return NotFound();
            }

            var userToDelete = _userRepository.GetUser(email);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_userRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }
    }
}