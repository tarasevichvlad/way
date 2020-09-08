using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateTripInfoRelationhips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerInfos",
                table: "PassengerInfos");

            migrationBuilder.DropIndex(
                name: "IX_PassengerInfos_TripId",
                table: "PassengerInfos");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("a446ee76-1e48-4d0a-aefd-f760b5d860ad"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("d0246d9c-840d-4d8b-9a41-567fdba31b0e"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PassengerInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerInfos",
                table: "PassengerInfos",
                columns: new[] { "TripId", "PassengerId" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("7c9ef652-900c-44cc-9235-1d4cea3c8604"), "Model 1" },
                    { new Guid("05ad720f-8a0d-4f44-a433-b436cb13b3e6"), "Model 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerInfos",
                table: "PassengerInfos");

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("05ad720f-8a0d-4f44-a433-b436cb13b3e6"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("7c9ef652-900c-44cc-9235-1d4cea3c8604"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PassengerInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerInfos",
                table: "PassengerInfos",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { new Guid("d0246d9c-840d-4d8b-9a41-567fdba31b0e"), "Model 1" },
                    { new Guid("a446ee76-1e48-4d0a-aefd-f760b5d860ad"), "Model 2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerInfos_TripId",
                table: "PassengerInfos",
                column: "TripId");
        }
    }
}
