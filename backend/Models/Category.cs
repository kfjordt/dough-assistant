using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS8618

namespace BudgetBffBackend.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        // Define a foreign key to the User entity
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
