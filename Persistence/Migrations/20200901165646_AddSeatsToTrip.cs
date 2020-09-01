using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddSeatsToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("976c8c3c-2838-481a-8c53-1efa6da31453"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("f9a10253-f4b5-4804-9c4c-69e4b8970b11"));

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("d0246d9c-840d-4d8b-9a41-567fdba31b0e"), "Model 1" },
                    { new Guid("a446ee76-1e48-4d0a-aefd-f760b5d860ad"), "Model 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a446ee76-1e48-4d0a-aefd-f760b5d860ad"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("d0246d9c-840d-4d8b-9a41-567fdba31b0e"));

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Trips");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("f9a10253-f4b5-4804-9c4c-69e4b8970b11"), "Model 1" },
                    { new Guid("976c8c3c-2838-481a-8c53-1efa6da31453"), "Model 2" }
                });
        }
    }
}
