using DoughAssistantBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public List<Expense> Expenses { get; set; }

        public List<Category> Categories { get; set; }
    }
}
