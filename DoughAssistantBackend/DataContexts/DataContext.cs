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
        public DbSet<SessionToken> SessionTokens { get; set; }
        public DbSet<RememberMeToken> RememberMeTokens { get; set; }
        public DbSet<UserConfiguration> UserConfigurations { get; set; }
        public DbSet<MonthCurrency> MonthCurrencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasOne(u => u.SessionToken)
               .WithOne(s => s.User)
               .HasForeignKey<SessionToken>(s => s.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.RememberMeToken)
                .WithOne(r => r.User)
                .HasForeignKey<RememberMeToken>(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId) 
                .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<User>()
            //     .HasOne(u => u.UserConfiguration)
            //     .WithOne(uc => uc.User)
            //     .HasForeignKey<UserConfiguration>(uc => uc.UserId);
            //
            // modelBuilder.Entity<User>()
            //     .HasMany(u => u.MonthCurrencies)
            //     .WithOne(m => m.User)
            //     .HasForeignKey(m => m.UserId);
        }
    }
}