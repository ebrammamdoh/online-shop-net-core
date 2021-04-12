using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionEn = table.Column<string>(nullable: false),
                    DescriptionAr = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UOMs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UOMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false),
                    TaxCode = table.Column<string>(nullable: true),
                    TaxValue = table.Column<decimal>(nullable: false),
                    DiscountCode = table.Column<string>(nullable: true),
                    DiscountValue = table.Column<decimal>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DuoDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    UOMId = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_UOMs_UOMId",
                        column: x => x.UOMId,
                        principalTable: "UOMs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributeNameItem",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false),
                    AttributeNameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeNameItem", x => new { x.ItemId, x.AttributeNameId });
                    table.ForeignKey(
                        name: "FK_AttributeNameItem_AttributeNames_AttributeNameId",
                        column: x => x.AttributeNameId,
                        principalTable: "AttributeNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeNameItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHeaderId = table.Column<int>(nullable: false),
                    ItemId = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<decimal>(type: "money", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: false),
                    UOMId = table.Column<int>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderHeaders_OrderHeaderId",
                        column: x => x.OrderHeaderId,
                        principalTable: "OrderHeaders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_UOMs_UOMId",
                        column: x => x.UOMId,
                        principalTable: "UOMs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AttributeNames",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "T1" },
                    { 2, "T2" },
                    { 3, "T3" },
                    { 4, "T4" },
                    { 5, "T5" },
                    { 6, "T6" },
                    { 7, "T7" },
                    { 8, "T8" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "DescriptionAr", "DescriptionEn", "UserId" },
                values: new object[,]
                {
                    { 100, "شركة سيانا", "Siana Company", null },
                    { 101, "شركة مادا", "Mada Company", null }
                });

            migrationBuilder.InsertData(
                table: "UOMs",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Kilo Gram", "KG" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "Name", "Qty", "UOMId", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "A1", "A1", 10000, 1, 0m },
                    { 2, "A2", "A2", 2500, 1, 0m },
                    { 3, "A3", "A3", 3700, 1, 0m }
                });

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "Id", "CustomerId", "DiscountCode", "DiscountValue", "DuoDate", "OrderDate", "RequestDate", "Status", "TaxCode", "TaxValue", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 100, "02", 60m, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "10", 100m, 100m },
                    { 2, 101, "03", 90m, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "10", 90m, 100m }
                });

            migrationBuilder.InsertData(
                table: "AttributeNameItem",
                columns: new[] { "ItemId", "AttributeNameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 7 },
                    { 3, 5 },
                    { 3, 3 },
                    { 3, 2 },
                    { 3, 1 },
                    { 2, 8 },
                    { 2, 7 },
                    { 2, 6 },
                    { 2, 5 },
                    { 3, 8 },
                    { 2, 4 },
                    { 2, 2 },
                    { 2, 1 },
                    { 1, 8 },
                    { 1, 7 },
                    { 1, 5 },
                    { 1, 4 },
                    { 1, 3 },
                    { 1, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ItemId", "ItemPrice", "OrderHeaderId", "Quantity", "Tax", "TotalPrice", "UOMId" },
                values: new object[,]
                {
                    { 1, 0m, 1, 1500m, 1, 2, 14m, 3000m, 1 },
                    { 2, 30m, 2, 200m, 1, 5, 14m, 1000m, 1 },
                    { 3, 10m, 3, 2800m, 2, 1, 14m, 2800m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeNameItem_AttributeNameId",
                table: "AttributeNameItem",
                column: "AttributeNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_UOMId",
                table: "Items",
                column: "UOMId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemId",
                table: "OrderDetails",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderHeaderId",
                table: "OrderDetails",
                column: "OrderHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_UOMId",
                table: "OrderDetails",
                column: "UOMId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_CustomerId",
                table: "OrderHeaders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeNameItem");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AttributeNames");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "UOMs");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
