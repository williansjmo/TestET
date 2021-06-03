using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Infrastructure.Migrations
{
    public partial class editTravellers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travellers_Passenger_PassengerId",
                table: "Travellers");

            migrationBuilder.DropColumn(
                name: "PassengeId",
                table: "Travellers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerId",
                table: "Travellers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Travellers_Passenger_PassengerId",
                table: "Travellers",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travellers_Passenger_PassengerId",
                table: "Travellers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PassengerId",
                table: "Travellers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "PassengeId",
                table: "Travellers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Travellers_Passenger_PassengerId",
                table: "Travellers",
                column: "PassengerId",
                principalTable: "Passenger",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
