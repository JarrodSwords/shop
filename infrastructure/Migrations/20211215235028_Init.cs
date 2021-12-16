using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Baguettes = table.Column<int>(type: "int", nullable: false),
                    CouplesBoxes = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DessertBoxes = table.Column<int>(type: "int", nullable: false),
                    FamilyBoxes = table.Column<int>(type: "int", nullable: false),
                    IsGift = table.Column<bool>(type: "bit", nullable: false),
                    IsSpecialOccasion = table.Column<bool>(type: "bit", nullable: false),
                    LunchBoxes = table.Column<int>(type: "int", nullable: false),
                    PartyBoxes = table.Column<int>(type: "int", nullable: false),
                    Strawberries = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
