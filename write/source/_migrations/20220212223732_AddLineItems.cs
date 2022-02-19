using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Write._migrations
{
    public partial class AddLineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "LineItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Order_OrderId",
                table: "LineItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Order_OrderId",
                table: "LineItem");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "LineItem");
        }
    }
}
