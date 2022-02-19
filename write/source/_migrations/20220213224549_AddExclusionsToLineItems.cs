using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Write._migrations
{
    public partial class AddExclusionsToLineItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingApricots",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingBerries",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingBleuCheese",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingBrie",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingCaramel",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingCherry",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingChocolate",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingDill",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingGarlic",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingGoatCheese",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingGrapes",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingGreenOlives",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingHoney",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingKalamataOlives",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingMustard",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingNuts",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingPeppers",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingPomegranateSeeds",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingProsciutto",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingSalami",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingSharpCheeses",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingSpicy",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsExcludingVanilla",
                table: "LineItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsExcludingApricots",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingBerries",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingBleuCheese",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingBrie",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingCaramel",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingCherry",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingChocolate",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingDill",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingGarlic",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingGoatCheese",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingGrapes",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingGreenOlives",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingHoney",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingKalamataOlives",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingMustard",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingNuts",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingPeppers",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingPomegranateSeeds",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingProsciutto",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingSalami",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingSharpCheeses",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingSpicy",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsExcludingVanilla",
                table: "LineItem");
        }
    }
}
