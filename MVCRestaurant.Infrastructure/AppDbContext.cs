using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder Builder)
        {
            base.OnModelCreating(Builder);

            #region seed data

            Builder.Entity<AppUser>().HasData(SeedData.GetSeedUsers());
            Builder.Entity<IdentityRole>().HasData(SeedData.GetSeedRoles());
            Builder.Entity<IdentityUserRole<string>>().HasData(SeedData.GetSeedUserRoles());

            #endregion

            #region foreign keys
            //Builder.Entity<AppUser>().HasAlternateKey(e => e.AltKey);

            // Food <n-1> Category
            Builder.Entity<FoodItem>()
                .HasOne(x => x.Category)
                .WithMany(x => x.FoodItems)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Food <1-n> OrderItem
            Builder.Entity<OrderItem>()
                .HasOne(x => x.OrderedFood)
                .WithMany(x => x.CorrespondingOrders)
                .HasForeignKey(x => x.OrderedFoodId)
                .OnDelete(DeleteBehavior.Restrict);

            // Order <1-n> OrderItem
            Builder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            // User <1-n> Order
            Builder.Entity<Order>()
                .HasOne(x => x.OrderedBy)
                .WithMany(x => x.Orders)
                .HasPrincipalKey(x => x.AltKey)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region Auto-generate

            Builder.Entity<AppUser>().Property(p => p.AltKey)
                .ValueGeneratedOnAdd();

            Builder.Entity<FoodCategory>().Property(p => p.Id)
                .ValueGeneratedOnAdd();

            Builder.Entity<FoodItem>().Property(p => p.Id)
                .ValueGeneratedOnAdd();

            Builder.Entity<Order>().Property(p => p.Identifier)
                .ValueGeneratedOnAdd();

            Builder.Entity<Log>().Property(p => p.Id)
                .ValueGeneratedOnAdd();

            #endregion

            #region Query Filters
            Builder.Entity<FoodItem>().HasQueryFilter(x => !x.IsDeleted);
            Builder.Entity<FoodCategory>().HasQueryFilter(x => !x.IsDeleted);
            Builder.Entity<OrderItem>().HasQueryFilter(x => x.quantity > 0);
            #endregion
        }
    }
}
