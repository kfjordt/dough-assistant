using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models;

public class AuthenticationToken
{
    [Key]
    public string Id { get; set; }
    [NotMapped]
    public string Key { get; set; }
    public string HashedKey { get; set; }
    public DateTime ExpiryDate { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
}