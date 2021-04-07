using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class updatingTablesNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "SubCategoryItem",
                newName: "SubCategoryItemName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "Promotion",
                newName: "PromotionName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "Item",
                newName: "ItemName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "ExtraIngredient",
                newName: "ExtraIngredientName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "CategoryItem",
                newName: "CategoryItemName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubCategoryItemName",
                schema: "Menues",
                table: "SubCategoryItem",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "PromotionName",
                schema: "Menues",
                table: "Promotion",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ItemName",
                schema: "Menues",
                table: "Item",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ExtraIngredientName",
                schema: "Menues",
                table: "ExtraIngredient",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryItemName",
                schema: "Menues",
                table: "CategoryItem",
                newName: "Name");
        }
    }
}
