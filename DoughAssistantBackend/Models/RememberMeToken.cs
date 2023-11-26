using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models;

public class RememberMeToken
{
    [Key]
    public string RememberBeTokenId { get; set; }
    [NotMapped]
    public string Token { get; set; }
    public string HashedToken { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}