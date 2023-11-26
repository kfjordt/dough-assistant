using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using Microsoft.AspNetCore.Authorization;
using DoughAssistantBackend.Services;
using DoughAssistantBackend.Repository;

namespace DoughAssistantBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationRepository _authenticationRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper, IAuthenticationRepository authenticationRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _authenticationRepository = authenticationRepository;
        }
        
        
        // post userconfig
        // get userconfig
        // update userconfig
        
        
        // post month currency
        // get month currency
        // update month currency
    }
}