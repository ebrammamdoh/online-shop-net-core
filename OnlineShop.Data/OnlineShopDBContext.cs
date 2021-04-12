using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OnlineShop.Data
{
    public class OnlineShopDBContext : DbContext
    {
        public OnlineShopDBContext(DbContextOptions<OnlineShopDBContext> options) : base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<UOM> UOMs { get; set; }
        public DbSet<AttributeName> AttributeNames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<AttributeNameItem>().HasKey(p => new { p.ItemId, p.AttributeNameId });
            SeedData.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
