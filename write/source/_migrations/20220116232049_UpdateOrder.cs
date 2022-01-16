using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Write._migrations
{
    public partial class UpdateOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Order",
                newName: "Refunded");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsAwaitingConfirmation",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAwaitingFulfillment",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAwaitingPayment",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCanceled",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPending",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefundDue",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefunded",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Paid",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsAwaitingConfirmation",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsAwaitingFulfillment",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsAwaitingPayment",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsCanceled",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsPending",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsRefundDue",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsRefunded",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Paid",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "Refunded",
                table: "Order",
                newName: "Total");
        }
    }
}
