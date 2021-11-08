using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class RenaminItemCategoryInItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MenuSubCategory_MenuCategoryId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "MenuSubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_MenuSubcategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_BranchId_Order_MenuSubcategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_MenuSubCategory_MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                column: "MenuSubcategoryId",
                principalSchema: "Menu",
                principalTable: "MenuSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MenuSubCategory_MenuSubcategoryId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                newName: "MenuCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_MenuCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_BranchId_Order_MenuCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_MenuSubCategory_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                column: "MenuCategoryId",
                principalSchema: "Menu",
                principalTable: "MenuSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
