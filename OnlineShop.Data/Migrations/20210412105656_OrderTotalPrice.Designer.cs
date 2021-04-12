﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineShop.Data;

namespace OnlineShop.Data.Migrations
{
    [DbContext(typeof(OnlineShopDBContext))]
    [Migration("20210412105656_OrderTotalPrice")]
    partial class OrderTotalPrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineShop.Data.Entities.AttributeName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AttributeNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "T1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "T2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "T3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "T4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "T5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "T6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "T7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "T8"
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.AttributeNameItem", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("AttributeNameId")
                        .HasColumnType("int");

                    b.HasKey("ItemId", "AttributeNameId");

                    b.HasIndex("AttributeNameId");

                    b.ToTable("AttributeNameItem");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 1
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 2
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 3
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 4
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 5
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 7
                        },
                        new
                        {
                            ItemId = 1,
                            AttributeNameId = 8
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 1
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 2
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 3
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 4
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 5
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 6
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 7
                        },
                        new
                        {
                            ItemId = 2,
                            AttributeNameId = 8
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 1
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 2
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 3
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 5
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 7
                        },
                        new
                        {
                            ItemId = 3,
                            AttributeNameId = 8
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescriptionAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 100,
                            DescriptionAr = "شركة سيانا",
                            DescriptionEn = "Siana Company",
                            UserId = "42d9354c-38a1-4e39-91de-dce6dd2e9d66"
                        },
                        new
                        {
                            Id = 101,
                            DescriptionAr = "شركة مادا",
                            DescriptionEn = "Mada Company",
                            UserId = "0551f159-7455-460a-8582-b3a143406059"
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qty")
                        .HasColumnType("int");

                    b.Property<int>("UOMId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("UOMId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A1",
                            Name = "A1",
                            Qty = 10000,
                            UOMId = 1,
                            UnitPrice = 100m
                        },
                        new
                        {
                            Id = 2,
                            Description = "A2",
                            Name = "A2",
                            Qty = 2500,
                            UOMId = 1,
                            UnitPrice = 20m
                        },
                        new
                        {
                            Id = 3,
                            Description = "A3",
                            Name = "A3",
                            Qty = 3700,
                            UOMId = 1,
                            UnitPrice = 120m
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("money");

                    b.Property<int>("OrderHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalAfterDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money");

                    b.Property<int>("UOMId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderHeaderId");

                    b.HasIndex("UOMId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.OrderHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("DiscountValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("DuoDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("RequestDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaxCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TaxValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.UOM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UOMs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Kilo Gram",
                            Name = "KG"
                        });
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.AttributeNameItem", b =>
                {
                    b.HasOne("OnlineShop.Data.Entities.AttributeName", "AttributeName")
                        .WithMany("AttributeNameItems")
                        .HasForeignKey("AttributeNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Data.Entities.Item", "Item")
                        .WithMany("AttributeNameItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.Item", b =>
                {
                    b.HasOne("OnlineShop.Data.Entities.UOM", "UOM")
                        .WithMany("Items")
                        .HasForeignKey("UOMId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.OrderDetails", b =>
                {
                    b.HasOne("OnlineShop.Data.Entities.Item", "Item")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("OnlineShop.Data.Entities.OrderHeader", "OrderHeader")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineShop.Data.Entities.UOM", "UOM")
                        .WithMany("OrderDetails")
                        .HasForeignKey("UOMId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineShop.Data.Entities.OrderHeader", b =>
                {
                    b.HasOne("OnlineShop.Data.Entities.Customer", "Customer")
                        .WithMany("OrderHeaders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
