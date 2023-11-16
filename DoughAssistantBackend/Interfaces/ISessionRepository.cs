using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface ISessionRepository : IRepository
    {
        bool CreateSession(Session session);
        User GetUser(string sessionId);
    }
}
