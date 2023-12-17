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

        public static CookieOptions DefaultCookieOptions = new CookieOptions()
        {
            Secure = true,
            HttpOnly = true,
            SameSite = SameSiteMode.None
        };
        
        public struct CookieNames
        {
            public const string SessionCookieId = "DoughAssistant_SessionCookieId";
            public const string SessionCookieKey = "DoughAssistant_SessionCookieKey";
            public const string RememberMeCookieId = "DoughAssistant_RememberMeCookieId";
            public const string RememberMeCookieKey = "DoughAssistant_RememberMeCookieKey";
        }
        
        public AuthenticationToken GenerateAuthenticationToken(string userId)
        {
            string tokenId = GenerateRandomNumber(128);
            string tokenKey = GenerateRandomNumber(128);
            string hashedTokenKey = HashWithSha256(tokenKey);
        
            AuthenticationToken rememberMeToken = new AuthenticationToken
            {
                Id = tokenId,
                Key = tokenKey,
                HashedKey = hashedTokenKey,
                UserId = userId,
            };
        
            return rememberMeToken;
        }
        
        public bool ValidateToken(string cookieKey, AuthenticationToken tokenFromDb)
        {
            return tokenFromDb.HashedKey == HashWithSha256(cookieKey);
        }

        public AuthenticationToken RenewToken(AuthenticationToken token)
        {
            var renewedKey = GenerateRandomNumber(128);
            var renewedHashedKey = HashWithSha256(renewedKey);

            var renewedToken = new AuthenticationToken()
            {
                ExpiryDate = token.ExpiryDate,
                HashedKey = renewedHashedKey,
                Key = renewedKey,
                Id = token.Id,
                UserId = token.UserId
            };

            return renewedToken;
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