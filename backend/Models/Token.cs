using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace BudgetBffBackend.Models
{
    public class Token
    {
        [Key]
        public string TokenContent { get; set; }

        public DateTime ExpiryDate { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
