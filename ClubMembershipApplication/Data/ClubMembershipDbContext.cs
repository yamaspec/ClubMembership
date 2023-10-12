using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace ClubMembershipApplication.Data
{
    public class ClubMembershipDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Data Source=DESKTOP-NMFR4FA;Initial Catalog=ClubMembership;User ID=sa;Password=#$AkSMx%178%&")
                .LogTo(Console.WriteLine, LogLevel.Information);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
