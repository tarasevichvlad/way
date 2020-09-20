using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("50dea0a4-790d-4605-a2db-5439af76cead"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ffefab83-5862-4d24-9ed5-bafd019a828e"));

            migrationBuilder.AddColumn<bool>(
                name: "OnlyTwoBehind",
                table: "Trips",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "RegistrationPlate" },
                values: new object[,]
                {
                    { new Guid("9510ba24-0a4e-4dfa-b023-010e1c534190"), "Model 1", null },
                    { new Guid("e8db97cc-2838-49fa-b8ab-d98ac1abb122"), "Model 2", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9510ba24-0a4e-4dfa-b023-010e1c534190"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e8db97cc-2838-49fa-b8ab-d98ac1abb122"));

            migrationBuilder.DropColumn(
                name: "OnlyTwoBehind",
                table: "Trips");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "RegistrationPlate" },
                values: new object[,]
                {
                    { new Guid("ffefab83-5862-4d24-9ed5-bafd019a828e"), "Model 1", null },
                    { new Guid("50dea0a4-790d-4605-a2db-5439af76cead"), "Model 2", null }
                });
        }
    }
}
