using System;
using System.Collections.Generic;
using System.Text;
using BudgetPal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetPal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountLog> AccountLogs { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalLog> GoalLogs { get; set; }
        public DbSet<LogType> LogTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed new user
            ApplicationUser user = new ApplicationUser
            {
                FirstName = "James",
                LastName = "Nitz",
                UserName = "james@james.com",
                NormalizedUserName = "JAMES@JAMES.COM",
                Email = "james@james.com",
                NormalizedEmail = "JAMES@JAMES.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<LogType>().HasData(
                new LogType()
                {
                Id = 1,
                ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                Name = "Rent/Utilities"
                },
                new LogType()
                {
                    Id = 2,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Name = "Insurance"
                },
                new LogType()
                {
                    Id = 3,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Name = "Groceries"
                },
                new LogType()
                {
                    Id = 4,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Name = "Fun Stuff"
                },
                new LogType()
                {
                    Id = 5,
                    ApplicationUserId = "00000000-ffff-ffff-ffff-ffffffffffff",
                    Name = "Miscellaneous"
                }
            );
        }
    }
}
