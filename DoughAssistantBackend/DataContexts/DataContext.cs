using Microsoft.EntityFrameworkCore;
using DoughAssistantBackend.Models;

namespace DoughAssistantBackend.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasOne(u => u.Session)
               .WithOne(s => s.User)
               .HasForeignKey<Session>(s => s.UserId)
               .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete Expenses when a User is deleted
        }
    }
}