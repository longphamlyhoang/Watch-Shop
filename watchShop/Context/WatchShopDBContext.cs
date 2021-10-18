using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using watchShop.Entities;

namespace watchShop.Context
{
    public class WatchShopDBContext : IdentityDbContext<AppUser>
    {
        public WatchShopDBContext(DbContextOptions<WatchShopDBContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedingCategory(modelBuilder);
            SeedingUsers(modelBuilder);
            SeedingRoles(modelBuilder);
            SeedingUserRoles(modelBuilder);
        }
        private void SeedingCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Đồng hồ nam",
                    Description = "Đồng hồ nam",
                    Picture = "fas fa-alarm-clock",
                    Status = true
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Đồng hồ nữ",
                    Description = "Đồng hồ nữ",
                    Picture = "fas fa-alarm-clock",
                    Status = true
                });
        }
        private void SeedingUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Long pham",
                Email = "Long.pham@gmail.com",
                NormalizedEmail = "Long.pham@gmail.com",
                NormalizedUserName = "Long pham",
                LockoutEnabled = false,
                PhoneNumber = "0935140923",
                Avatar = "~/Images/avatar.png"
            };
            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Asdf1234!");
            builder.Entity<AppUser>().HasData(user);

        }
        private void SeedingRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "SystemAdmin", ConcurrencyStamp = "1", NormalizedName = "System Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" }
                );
        }
        private void SeedingUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
