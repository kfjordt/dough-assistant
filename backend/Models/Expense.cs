#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetBffBackend.Models
{
    public class Expense
    {
        [Key]
        public string ExpenseId { get; set; }

        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public double Amount { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
