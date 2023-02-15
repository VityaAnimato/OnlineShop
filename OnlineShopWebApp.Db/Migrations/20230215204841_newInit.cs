using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class newInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("1b4a32db-759e-47fb-ae8d-e7b09e29f74b"));

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[] { new Guid("3f9ad6e0-7137-431f-a13e-f152d279b6a2"), new Guid("93c88b3c-855c-494d-a6ce-112dcfe988e9"), "/images/Products/image1.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f8de36-a3ea-40fd-ac04-22c12de5ecec"),
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 7500m, "TEMP 140 TONE Em", "Beat #1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93c88b3c-855c-494d-a6ce-112dcfe988e9"),
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 7700m, "TEMP 144 TONE Dm", "Beat #2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("3f9ad6e0-7137-431f-a13e-f152d279b6a2"));

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "ProductId", "Url" },
                values: new object[] { new Guid("1b4a32db-759e-47fb-ae8d-e7b09e29f74b"), new Guid("93c88b3c-855c-494d-a6ce-112dcfe988e9"), "/images/Products/image2.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("46f8de36-a3ea-40fd-ac04-22c12de5ecec"),
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 10m, "Desc1", "Name1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("93c88b3c-855c-494d-a6ce-112dcfe988e9"),
                columns: new[] { "Cost", "Description", "Name" },
                values: new object[] { 10m, "Desc2", "Name2" });
        }
    }
}
