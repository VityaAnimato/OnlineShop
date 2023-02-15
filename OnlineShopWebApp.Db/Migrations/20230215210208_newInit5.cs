using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class newInit5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d1342b38-d971-4c5f-aeba-3efcd2592245"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ee5d1b8f-4fdc-41ef-9f4d-dcf9f21639ed"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("d1342b38-d971-4c5f-aeba-3efcd2592245"), 7900m, "TEMP 140 TONE Em", "Beat #3" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Cost", "Description", "Name" },
                values: new object[] { new Guid("ee5d1b8f-4fdc-41ef-9f4d-dcf9f21639ed"), 7777m, "TEMP 99 TONE Am", "Beat #4" });
        }
    }
}
