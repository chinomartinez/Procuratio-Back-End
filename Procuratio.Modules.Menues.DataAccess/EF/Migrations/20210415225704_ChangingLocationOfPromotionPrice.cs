using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class ChangingLocationOfPromotionPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                schema: "Menues",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "DinerInPrice",
                schema: "Menues",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "MenuPrice",
                schema: "Menues",
                table: "Promotion");

            migrationBuilder.DropColumn(
                name: "TakeAwayPrice",
                schema: "Menues",
                table: "Promotion");

            migrationBuilder.AddColumn<decimal>(
                name: "PromotionPrice",
                schema: "Menues",
                table: "Item",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PromotionPrice",
                schema: "Menues",
                table: "ExtraIngredient",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                schema: "Menues",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PromotionPrice",
                schema: "Menues",
                table: "ExtraIngredient");

            migrationBuilder.AddColumn<decimal>(
                name: "DeliveryPrice",
                schema: "Menues",
                table: "Promotion",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DinerInPrice",
                schema: "Menues",
                table: "Promotion",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MenuPrice",
                schema: "Menues",
                table: "Promotion",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TakeAwayPrice",
                schema: "Menues",
                table: "Promotion",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);
        }
    }
}
