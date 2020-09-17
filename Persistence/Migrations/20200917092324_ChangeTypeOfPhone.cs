using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangeTypeOfPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("05ad720f-8a0d-4f44-a433-b436cb13b3e6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7c9ef652-900c-44cc-9235-1d4cea3c8604"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("2ed21b95-90df-4126-9164-43586dd803c7"), "Model 1" },
                    { new Guid("e441b1e8-6024-44ab-a450-8a5d49159c23"), "Model 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("2ed21b95-90df-4126-9164-43586dd803c7"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("e441b1e8-6024-44ab-a450-8a5d49159c23"));

            migrationBuilder.AlterColumn<int>(
                name: "Phone",
                table: "Users",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("7c9ef652-900c-44cc-9235-1d4cea3c8604"), "Model 1" },
                    { new Guid("05ad720f-8a0d-4f44-a433-b436cb13b3e6"), "Model 2" }
                });
        }
    }
}
