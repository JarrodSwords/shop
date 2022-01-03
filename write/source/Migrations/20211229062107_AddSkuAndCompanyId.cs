using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Infrastructure.Migrations
{
    public partial class AddSkuAndCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "RecordName",
                table: "Product",
                newName: "Sku");

            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "Sku",
                table: "Product",
                newName: "RecordName");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Product",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
