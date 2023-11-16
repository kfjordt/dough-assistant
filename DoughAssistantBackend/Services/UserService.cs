using AutoMapper;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Services
{
    public class UserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public User GenerateNewUser(UserDto userToCreate)
        {
            var newUser = _mapper.Map<User>(userToCreate);
            newUser.RegistrationDate = DateTime.UtcNow;

            return newUser;
        }
    }
}
