using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoughAssistantBackend.Models
{
    public class SessionToken
    {
        [Key]
        public string Id { get; set; }
        [NotMapped]
        public string Key { get; set; }
        public string HashedKey { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
