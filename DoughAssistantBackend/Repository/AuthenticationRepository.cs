using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
using DoughAssistantBackend.Services;
using Microsoft.EntityFrameworkCore;

namespace DoughAssistantBackend.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {

        private readonly DataContext _context;

        public AuthenticationRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateSession(SessionToken sessionToken)
        {
            _context.Add(sessionToken);
            return Save();
        }

        public SessionToken GetSessionByUserId(string userId)
        {
            return _context.SessionTokens.Where(session => session.UserId == userId).FirstOrDefault();
        }

        public User GetUser(string sessionKey)
        {
            return _context.SessionTokens
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
            return _context.SessionTokens.Any(session => session.SessionKey == sessionKey);
        }

        public bool UserHasSession(string userId)
        {
            return _context.SessionTokens.Any(session => session.UserId == userId);
        }
    }
}
