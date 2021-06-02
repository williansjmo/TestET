using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelAgency.Infrastructure.Migrations
{
    public partial class Travel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Travel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TravelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfSeats = table.Column<double>(type: "float", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travel");
        }
    }
}
