using AutoMapper;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;
using Newtonsoft.Json.Linq;

namespace DoughAssistantBackend.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Expense, ExpenseDto>();
            CreateMap<ExpenseDto, Expense>();
            
            CreateMap<RememberMeToken, RememberMeTokenDto>();
            CreateMap<RememberMeTokenDto, RememberMeToken>();
            
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>()
                .AfterMap((src, dest) => dest.RegistrationDate = DateTime.UtcNow); 

            CreateMap<JToken, GoogleTokenInfoDto>()
                .ForMember(dest => dest.Azp, opt => opt.MapFrom(src => src["azp"].ToString()))
                .ForMember(dest => dest.Aud, opt => opt.MapFrom(src => src["aud"].ToString()))
                .ForMember(dest => dest.Sub, opt => opt.MapFrom(src => src["sub"].ToString()))
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src["scope"].ToString()))
                .ForMember(dest => dest.Exp, opt => opt.MapFrom(src => src["exp"].ToString()))
                .ForMember(dest => dest.ExpiresIn, opt => opt.MapFrom(src => src["expires_in"].ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src["email"].ToString()))
                .ForMember(dest => dest.EmailVerified, opt => opt.MapFrom(src => bool.Parse(src["email_verified"].ToString())))
                .ForMember(dest => dest.AccessType, opt => opt.MapFrom(src => src["access_type"].ToString()));

            CreateMap<JObject, UserDto>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src["sub"].ToString()))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"].ToString()))
                    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src["email"].ToString()));
        
        }
    }
}