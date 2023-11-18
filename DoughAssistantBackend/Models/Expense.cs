using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoughAssistantBackend.Models
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ExpenseId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public DateTime Time { get; set; }
        public string UserId {  get; set; }
        public User User { get; set; }
    }
}
