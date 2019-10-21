using BigNumberCalculator.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace BigNumberCalculator.Repository
{
    public class BigDataContext : DbContext
    {
        public BigDataContext(DbContextOptions<BigDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Calculation> Calculations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<User>().HasKey(c => c.ID);
            modelBuilder.Entity<User>().Property(b => b.ID).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasIndex(b => b.UserName).IsUnique();

            // Calculation
            modelBuilder.Entity<Calculation>().HasKey(c => c.ID);
            modelBuilder.Entity<Calculation>().Property(b => b.ID).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasMany(c => c.Calculations).WithOne(e => e.User).IsRequired();
        }
    }
}
