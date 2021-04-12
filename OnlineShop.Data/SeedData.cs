using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities;
using OnlineShop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data
{
    public class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UOM>().HasData(
                new UOM
                {
                    Id = 1,
                    Name = "KG",
                    Description = "Kilo Gram"
                }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 100,
                    DescriptionEn = "Siana Company",
                    DescriptionAr = "شركة سيانا",
                    UserId = "42d9354c-38a1-4e39-91de-dce6dd2e9d66"
                },
                new Customer
                {
                    Id = 101,
                    DescriptionEn = "Mada Company",
                    DescriptionAr = "شركة مادا",
                    UserId = "0551f159-7455-460a-8582-b3a143406059"
                }
            );

            modelBuilder.Entity<AttributeName>().HasData(
                new AttributeName { Id = 1, Name = "T1" },
                new AttributeName { Id = 2, Name = "T2" },
                new AttributeName { Id = 3, Name = "T3" },
                new AttributeName { Id = 4, Name = "T4" },
                new AttributeName { Id = 5, Name = "T5" },
                new AttributeName { Id = 6, Name = "T6" },
                new AttributeName { Id = 7, Name = "T7" },
                new AttributeName { Id = 8, Name = "T8" }
                );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "A1",
                    Description = "A1",
                    UOMId = 1,
                    Qty = 10000,
                    UnitPrice = 100
                },
                new Item
                {
                    Id = 2,
                    Name = "A2",
                    Description = "A2",
                    UOMId = 1,
                    Qty = 2500,
                    UnitPrice = 20
                },
                new Item
                {
                    Id = 3,
                    Name = "A3",
                    Description = "A3",
                    UOMId = 1,
                    Qty = 3700,
                    UnitPrice = 120
                }
            );
            modelBuilder.Entity<AttributeNameItem>().HasData(
              new AttributeNameItem { ItemId = 1, AttributeNameId = 1 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 2 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 3 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 4 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 5 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 7 },
              new AttributeNameItem { ItemId = 1, AttributeNameId = 8 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 1 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 2 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 3 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 4 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 5 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 6 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 7 },
              new AttributeNameItem { ItemId = 2, AttributeNameId = 8 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 1 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 2 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 3 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 5 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 7 },
              new AttributeNameItem { ItemId = 3, AttributeNameId = 8 }
            );

        }
    }
}
