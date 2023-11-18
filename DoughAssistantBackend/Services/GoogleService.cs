using AutoMapper;
using DoughAssistantBackend.Dto;
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

        public async Task<UserDto> VerifyAccessTokenAndGetUser(string accessToken)
        {
            var httpClient = new HttpClient();

            try
            {
                var googleTokenInfo = await GetTokenInfo(httpClient, accessToken);
                var userInfo = await GetUserInfo(httpClient, accessToken);

                return userInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating access token", ex);
            }
        }

        private async Task<GoogleTokenInfo> GetTokenInfo(HttpClient client, string token)
        {
            var tokenInfoEndpoint = $"{TokenInfoEndpoint}={token}";
            var response = await client.GetStringAsync(tokenInfoEndpoint);

            JObject tokenInfo = JObject.Parse(response);

            try
            {
                GoogleTokenInfo googleTokenInfo = _mapper.Map<GoogleTokenInfo>(tokenInfo);

                if (!googleTokenInfo.IsValid())
                {
                    throw new Exception("Token is invalid");
                }

                return googleTokenInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing Google's API response to token", ex);
            }
        }

        private async Task<UserDto> GetUserInfo(HttpClient client, string token)
        {
            var userInfoEndpoint = $"{UserInfoEndpoint}";

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var userInfoResponse = await client.GetStringAsync(userInfoEndpoint);

            JObject userInfo = JObject.Parse(userInfoResponse);

            try
            {
                UserDto userDto = _mapper.Map<UserDto>(userInfo);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing Google's API response to user info", ex);
            }
        } 
    }
}
