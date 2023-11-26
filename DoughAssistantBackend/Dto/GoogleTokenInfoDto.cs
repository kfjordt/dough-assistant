namespace DoughAssistantBackend.Dto
{
    public class GoogleTokenInfoDto
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
    }
}
