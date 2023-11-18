using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface ISessionRepository : IRepository
    {
        bool CreateSession(Session session);
        User GetUser(string sessionId);
        bool SessionExists(string sessionKey);
        bool UserHasSession(string userId);
        Session GetSessionByUserId(string userId); 
    }
}
