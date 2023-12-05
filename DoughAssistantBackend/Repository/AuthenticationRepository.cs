using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;
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

        public bool CreateSessionToken(SessionToken sessionToken)
        {
            _context.Add(sessionToken);
            return Save();
        }

        public SessionToken? GetSessionTokenByUserId(string userId)
        {
            return _context.SessionTokens.FirstOrDefault(session => session.UserId == userId);
        }

        public bool CreateRememberMeToken(AuthenticationToken token)
        {
            _context.Add(token);
            return Save();
        }

        public AuthenticationToken? GetRememberMeTokenById(string rememberMeTokenId)
        {
            return _context.RememberMeTokens
                .FirstOrDefault(token => token.RememberMeTokenId == rememberMeTokenId);
        }

        public bool RememberMeTokenExists(string rememberMeTokenDtoId)
        {
            return _context.RememberMeTokens.Any(token => token.RememberMeTokenId == rememberMeTokenDtoId);
        }

        public bool UpdateToken(AuthenticationToken newToken)
        {
            _context.Update(newToken);
            return Save();
        }

        public bool DeleteSessionsByUserId(string userId)
        {
            List<SessionToken> sessions = _context.SessionTokens
                .Where(token => token.UserId == userId)
                .ToList();

            _context.Remove(sessions);
            return Save();
        }

        public User? GetUserBySessionId(string sessionKey)
        {
            return _context.SessionTokens
                .Include(s => s.User) 
                .FirstOrDefault(s => s.SessionKey == sessionKey)
                ?.User;
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
