using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class AddRegistrationPlateToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2ed21b95-90df-4126-9164-43586dd803c7"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e441b1e8-6024-44ab-a450-8a5d49159c23"));

            migrationBuilder.AddColumn<string>(
                name: "RegistrationPlate",
                table: "Cars",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model", "RegistrationPlate" },
                values: new object[,]
                {
                    { new Guid("ffefab83-5862-4d24-9ed5-bafd019a828e"), "Model 1", null },
                    { new Guid("50dea0a4-790d-4605-a2db-5439af76cead"), "Model 2", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("50dea0a4-790d-4605-a2db-5439af76cead"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("ffefab83-5862-4d24-9ed5-bafd019a828e"));

            migrationBuilder.DropColumn(
                name: "RegistrationPlate",
                table: "Cars");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("2ed21b95-90df-4126-9164-43586dd803c7"), "Model 1" },
                    { new Guid("e441b1e8-6024-44ab-a450-8a5d49159c23"), "Model 2" }
                });
        }
    }
}
