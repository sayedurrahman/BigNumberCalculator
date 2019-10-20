using BigNumberCalculatorRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigNumberCalculatorRepository
{
    public class BigDataContext : DbContext
    {
        public BigDataContext(DbContextOptions<BigDataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Calculation> Calculation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .HasMany(c => c.Calculations)
                    .WithOne(e => e.User)
                    .IsRequired();
        }

    }
}
