using System.Xml;
#pragma warning disable CS8618

namespace BudgetBffBackend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string GoogleId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
