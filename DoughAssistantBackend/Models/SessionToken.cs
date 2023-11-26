using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoughAssistantBackend.Models
{
    public class SessionToken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionTokenId { get; set; }
        public string SessionKey { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
