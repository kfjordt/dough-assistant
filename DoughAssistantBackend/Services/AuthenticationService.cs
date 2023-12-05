using System.Security.Cryptography;
using System.Text;
using DoughAssistantBackend.Dto;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Services
{
    public class AuthenticationService
    {
        public AuthenticationService()
        {
        }

        public struct CookieNames
        {
            public const string SessionCookieId = "DoughAssistant_SessionCookieId";
            public const string SessionCookieKey = "DoughAssistant_SessionCookieKey";
            public const string RememberMeCookieId = "DoughAssistant_RememberMeCookieId";
            public const string RememberMeCookieKey = "DoughAssistant_RememberMeCookieKey";
        }

        public SessionToken GenerateNewSession(string userId)
        {
            var session = new SessionToken()
            {
                UserId = userId,
                SessionKey = Guid.NewGuid().ToString()
            };

            return session;
        }


        public AuthenticationToken GenerateNewRememberMeToken(string userId)
        {
            string seriesIdentifier = GenerateRandomNumber(128);
            string token = GenerateRandomNumber(128);
            string hashedToken = HashWithSha256(token);

            AuthenticationToken authenticationToken = new AuthenticationToken
            {
                RememberMeTokenId = seriesIdentifier,
                Token = token,
                HashedToken = hashedToken,
                UserId = userId,
            };

            return authenticationToken;
        }

        public bool ValidateToken(string cookieKey, AuthenticationToken tokenFromDb)
        {
            return tokenFromDb.HashedKey == HashWithSha256(cookieKey);
        }

        public AuthenticationToken RenewToken(AuthenticationToken oldToken)
        {
            string newToken = GenerateRandomNumber(128);
            return new AuthenticationToken
            {
                RememberMeTokenId = oldToken.RememberMeTokenId,
                Token = newToken,
                HashedToken = HashWithSha256(newToken),
                UserId = oldToken.UserId,
            };
        }

        private static string GenerateRandomNumber(int bits)
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(bits / 8));
        }

        private static string HashWithSha256(string input)
        {
            // Taken from https://stackoverflow.com/a/73126261/19391732
            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}