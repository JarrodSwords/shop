using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Write._migrations
{
    public partial class CreateDatabase : Migration
    {
        #region Protected Interface

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Customer"
            );

            migrationBuilder.DropTable(
                "Order"
            );

            migrationBuilder.DropTable(
                "Product"
            );

            migrationBuilder.DropTable(
                "Vendor"
            );
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Customer",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Email = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Customer", x => x.Id); }
            );

            migrationBuilder.CreateTable(
                "Order",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Subtotal = table.Column<decimal>("decimal(18,2)", nullable: false),
                    Tip = table.Column<decimal>("decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>("decimal(18,2)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Order", x => x.Id); }
            );

            migrationBuilder.CreateTable(
                "Product",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    IsBox = table.Column<bool>("bit", nullable: false),
                    IsDessert = table.Column<bool>("bit", nullable: false),
                    IsSide = table.Column<bool>("bit", nullable: false),
                    Description = table.Column<string>("nvarchar(max)", nullable: true),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Size = table.Column<int>("int", nullable: true),
                    Sku = table.Column<string>("nvarchar(max)", nullable: true),
                    VendorId = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>("decimal(18,2)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Product", x => x.Id); }
            );

            migrationBuilder.CreateTable(
                "Vendor",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    SkuToken = table.Column<string>("nvarchar(max)", nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Vendor", x => x.Id); }
            );
        }

        #endregion
    }
}
