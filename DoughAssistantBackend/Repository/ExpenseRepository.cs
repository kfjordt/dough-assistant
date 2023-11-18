using DoughAssistantBackend.DataContexts;
using DoughAssistantBackend.Interfaces;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DataContext _context;
        public ExpenseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateExpense(Expense expense)
        {
            _context.Add(expense);
            return Save();
        }

        public bool DeleteExpense(Expense expense)
        {
            _context.Remove(expense);
            return Save();
        }

        public ICollection<Expense> GetExpensesByUserId(string userId)
        {
            return _context.Expenses
                .Where(expense => expense.User.UserId == userId)
                .ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool UpdateExpense(Expense expense)
        {
            _context.Update(expense);
            return Save();
        }
    }
}
