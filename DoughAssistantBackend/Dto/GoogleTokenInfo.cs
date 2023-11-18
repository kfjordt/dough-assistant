namespace DoughAssistantBackend.Dto
{
    public class GoogleTokenInfo
    {
        public string Azp { get; set; }
        public string Aud { get; set; }
        public string Sub { get; set; }
        public string Scope { get; set; }
        public string Exp { get; set; }
        public string ExpiresIn { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string AccessType { get; set; }

        public bool IsValid()
        {
            //https://developers.google.com/identity/gsi/web/guides/verify-google-id-token
            return true;
        }
    }
}
