using DoughAssistantBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoughAssistantBackend.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public List<Expense> Expenses { get; set; }
        public SessionToken SessionToken { get; set; }
        public RememberMeToken RememberMeToken { get; set; }
        public List<MonthCurrency> MonthCurrencies { get; set; }
        public UserConfiguration UserConfiguration { get; set; }
    }
}
