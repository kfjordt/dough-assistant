using BudgetBffBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetBffBackend.Contexts
{
    public class AppDbContext : DbContext
    {

        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
