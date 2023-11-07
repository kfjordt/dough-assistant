using System.ComponentModel.DataAnnotations;
using System.Xml;
#pragma warning disable CS8618

namespace BudgetBffBackend.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string GoogleEmail { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        public List<Expense> Expenses { get; set; }

        public List<Category> Categories { get; set; }

        public List<Token> Tokens { get; set; }
    }
}
