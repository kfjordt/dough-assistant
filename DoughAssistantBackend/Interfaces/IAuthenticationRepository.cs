using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface ISessionRepository : IRepository
    {
        bool CreateSession(SessionToken sessionToken);
        User GetUser(string sessionId);
        bool SessionExists(string sessionKey);
        bool UserHasSession(string userId);
        SessionToken GetSessionByUserId(string userId); 
    }
}
