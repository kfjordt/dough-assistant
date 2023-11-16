using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using DoughAssistantBackend.Services;

namespace DoughAssistantBackend.Repository
{
    public class SessionRepository : ISessionRepository
    {

        private readonly DataContext _context;

        public SessionRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSession(Session session)
        {
            _context.Add(session);
            return Save();
        }

        public User GetUser(string sessionKey)
        {
            return _context.Sessions
                .Where(session => session.SessionKey == sessionKey)
                .FirstOrDefault()
                .User;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
