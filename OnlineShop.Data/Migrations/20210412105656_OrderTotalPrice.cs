using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Data.Migrations
{
    public partial class OrderTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderHeaders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<decimal>(
                name: "SubTotal",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAfterDiscount",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 100,
                column: "UserId",
                value: "42d9354c-38a1-4e39-91de-dce6dd2e9d66");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 101,
                column: "UserId",
                value: "0551f159-7455-460a-8582-b3a143406059");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitPrice",
                value: 100m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitPrice",
                value: 20m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitPrice",
                value: 120m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubTotal",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "TotalAfterDiscount",
                table: "OrderDetails");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 100,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 101,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3,
                column: "UnitPrice",
                value: 0m);

            migrationBuilder.InsertData(
                table: "OrderHeaders",
                columns: new[] { "Id", "CustomerId", "DiscountCode", "DiscountValue", "DuoDate", "OrderDate", "RequestDate", "Status", "TaxCode", "TaxValue", "TotalPrice" },
                values: new object[,]
                {
                    { 1, 100, "02", 60m, new DateTime(2019, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "10", 100m, 100m },
                    { 2, 101, "03", 90m, new DateTime(2019, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "10", 90m, 100m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ItemId", "ItemPrice", "OrderHeaderId", "Quantity", "Tax", "TotalPrice", "UOMId" },
                values: new object[] { 1, 0m, 1, 1500m, 1, 2, 14m, 3000m, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ItemId", "ItemPrice", "OrderHeaderId", "Quantity", "Tax", "TotalPrice", "UOMId" },
                values: new object[] { 2, 30m, 2, 200m, 1, 5, 14m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "Discount", "ItemId", "ItemPrice", "OrderHeaderId", "Quantity", "Tax", "TotalPrice", "UOMId" },
                values: new object[] { 3, 10m, 3, 2800m, 2, 1, 14m, 2800m, 1 });
        }
    }
}
