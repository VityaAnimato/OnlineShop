using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Db.Migrations
{
    public partial class newInit3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("3f9ad6e0-7137-431f-a13e-f152d279b6a2"),
                column: "Url",
                value: "/images/Products/2.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("7b6ddde3-c20a-467e-9299-e3fc34d91c66"),
                column: "Url",
                value: "/images/Products/1.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("3f9ad6e0-7137-431f-a13e-f152d279b6a2"),
                column: "Url",
                value: "/images/Products/image1.jpg");

            migrationBuilder.UpdateData(
                table: "Image",
                keyColumn: "Id",
                keyValue: new Guid("7b6ddde3-c20a-467e-9299-e3fc34d91c66"),
                column: "Url",
                value: "/images/Products/image1.jpg");
        }
    }
}
