using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class updatingStatesTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "SubCategoryItemState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "PromotionState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "ItemXPromotionState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "ItemState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "ExtraIngredientXItemState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "ExtraIngredientState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Menues",
                table: "CategoryItemState",
                newName: "StateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "SubCategoryItemState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "PromotionState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "ItemXPromotionState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "ItemState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "ExtraIngredientXItemState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "ExtraIngredientState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Menues",
                table: "CategoryItemState",
                newName: "Name");
        }
    }
}
