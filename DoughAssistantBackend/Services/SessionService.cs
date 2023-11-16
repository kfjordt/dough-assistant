using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Services
{
    public class SessionService
    {
        public SessionService() { }

        public Session GenerateNewSession(string userId)
        {
            var session = new Session()
            {
                UserId = userId,
                SessionKey = Guid.NewGuid().ToString()
            };

            return session;
        }
    }
}
