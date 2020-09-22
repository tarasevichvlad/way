using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddRatingToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("9510ba24-0a4e-4dfa-b023-010e1c534190"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e8db97cc-2838-49fa-b8ab-d98ac1abb122"));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Users",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "RegistrationPlate" },
                values: new object[,]
                {
                    { new Guid("766f1c51-e7c4-4642-88cc-aff8ea3efd73"), "Model 1", null },
                    { new Guid("5990f814-1925-4dda-80c7-165c57902cd5"), "Model 2", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("5990f814-1925-4dda-80c7-165c57902cd5"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("766f1c51-e7c4-4642-88cc-aff8ea3efd73"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "RegistrationPlate" },
                values: new object[,]
                {
                    { new Guid("9510ba24-0a4e-4dfa-b023-010e1c534190"), "Model 1", null },
                    { new Guid("e8db97cc-2838-49fa-b8ab-d98ac1abb122"), "Model 2", null }
                });
        }
    }
}
