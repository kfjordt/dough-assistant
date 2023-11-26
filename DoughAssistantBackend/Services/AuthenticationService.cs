using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Services
{
    public class AuthenticationService
    {
        public AuthenticationService() { }

        public SessionToken GenerateNewSession(string userId)
        {
            var session = new SessionToken()
            {
                UserId = userId,
                SessionKey = Guid.NewGuid().ToString()
            };

            return session;
        }
        
        
        // Request new token (upon initial login with 'remember me' enabled)
        // Is token valid (upon login)
    }
}
