using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using DoughAssistantBackend.Services;
using Microsoft.EntityFrameworkCore;

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

        public Session GetSessionByUserId(string userId)
        {
            return _context.Sessions.Where(session => session.UserId == userId).FirstOrDefault();
        }

        public User GetUser(string sessionKey)
        {
            return _context.Sessions
                .Include(s => s.User) 
                .FirstOrDefault(s => s.SessionKey == sessionKey).User;
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool SessionExists(string sessionKey)
        {
            return _context.Sessions.Any(session => session.SessionKey == sessionKey);
        }

        public bool UserHasSession(string userId)
        {
            return _context.Sessions.Any(session => session.UserId == userId);
        }
    }
}
