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

        public SessionToken GenerateNewSession(string userId)
        {
            var session = new SessionToken()
            {
                UserId = userId,
                SessionKey = Guid.NewGuid().ToString()
            };

            return session;
        }


        public RememberMeToken GenerateNewRememberMeToken(string userId)
        {
            string seriesIdentifier = GenerateRandomNumber(128);
            string token = GenerateRandomNumber(128);
            string hashedToken = HashWithSha256(token);

            RememberMeToken rememberMeToken = new RememberMeToken
            {
                RememberMeTokenId = seriesIdentifier,
                Token = token,
                HashedToken = hashedToken,
                UserId = userId,
            };

            return rememberMeToken;
        }

        public bool ValidateToken(string rememberMeCookieToken, RememberMeToken tokenFromDb)
        {
            return tokenFromDb.HashedToken == HashWithSha256(rememberMeCookieToken);
        }

        public RememberMeToken RenewToken(RememberMeToken oldToken)
        {
            string newToken = GenerateRandomNumber(128);
            return new RememberMeToken
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