using AutoMapper;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Helper
{
    public class UserMappingProfiles : Profile
    {
        public UserMappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}