using AutoMapper;
using DoughAssistantBackend.Dto;
using Google.Apis.Auth;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace DoughAssistantBackend.Services
{
    public class GoogleService
    {
        private const string TokenInfoEndpoint = "https://www.googleapis.com/oauth2/v3/tokeninfo?access_token";
        private const string UserInfoEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo";

        private readonly IMapper _mapper;

        public GoogleService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserDto> VerifyAccessTokenAndGetUser(string googleJwt)
        {
            try
            {
                var userInfo = await GetUserInfo(googleJwt);
                return userInfo;
            }
            catch (InvalidJwtException e)
            {
                throw new Exception("Token is invalid", e);
            }
        }

        private async Task<UserDto> GetUserInfo(string googleJwt)
        {
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(googleJwt);
            UserDto user = new()
            {
                UserId = payload.Subject,
                Email = payload.Email,
                Name = payload.Name,
            };

            return user;
        }
    }
}
