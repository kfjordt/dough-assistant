using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Interfaces
{
    public interface IAuthenticationRepository : IRepository
    {
        bool CreateSessionToken(AuthenticationToken sessionToken);

        AuthenticationToken GetSessionTokenBySessionCookieId(string cookieId);
        AuthenticationToken GetRememberMeTokenByRememberMeCookieId(string cookieId);
        AuthenticationToken UpdateRememberMeToken(AuthenticationToken rememberMeToken);
        
        
        
        // bool CreateSessionToken(SessionToken sessionToken);
        // RememberMeToken? GetRememberMeTokenByCookieId(string cookieId);
        // User? GetUserBySessionId(string sessionId);
        // bool SessionExists(string sessionKey);
        // bool UserHasSession(string userId);
        // SessionToken? GetSessionTokenByUserId(string userId);
        // bool CreateRememberMeToken(RememberMeToken token);
        // RememberMeToken? GetRememberMeTokenById(string rememberMeTokenId);
        // bool RememberMeTokenExists(string rememberMeTokenDtoId);
        // bool UpdateToken(RememberMeToken newToken);
        // bool DeleteSessionsByUserId(string userId);
    }
}
