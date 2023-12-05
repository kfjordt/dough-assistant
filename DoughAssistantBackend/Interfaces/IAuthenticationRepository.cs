using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface IAuthenticationRepository : IRepository
    {
        bool CreateSessionToken(SessionToken sessionToken);
        AuthenticationToken? GetSessionTokenByCookieId(string cookieId);
        AuthenticationToken? GetRememberMeTokenByCookieId(string cookieId);
        User? GetUserBySessionId(string sessionId);
        bool SessionExists(string sessionKey);
        bool UserHasSession(string userId);
        SessionToken? GetSessionTokenByUserId(string userId);
        bool CreateRememberMeToken(AuthenticationToken token);
        AuthenticationToken? GetRememberMeTokenById(string rememberMeTokenId);
        bool RememberMeTokenExists(string rememberMeTokenDtoId);
        bool UpdateToken(AuthenticationToken newToken);
        bool DeleteSessionsByUserId(string userId);
    }
}
