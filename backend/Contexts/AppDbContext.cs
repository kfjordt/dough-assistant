using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BudgetBffBackend.Models;

namespace BudgetBffBackend.Contexts
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration _configuration;

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(c => c.Categories)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Token>()
                .HasOne(u => u.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}
