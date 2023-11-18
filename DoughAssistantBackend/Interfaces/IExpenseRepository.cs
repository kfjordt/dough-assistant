using DoughAssistantBackend.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace DoughAssistantBackend.Interfaces
{
    public interface IExpenseRepository : IRepository
    {
        ICollection<Expense> GetExpensesByUserId(string userId);
        bool CreateExpense(Expense expense);    
        bool UpdateExpense(Expense expense);
        bool DeleteExpense(Expense expense);
    }
}
