using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class RemovingBranchIdOrderIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenuCategory_BranchId_Order",
                schema: "Menu",
                table: "MenuCategory");

            migrationBuilder.DropIndex(
                name: "IX_Item_BranchId_Order_MenuCategoryId",
                schema: "Menu",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_BranchId_Order",
                schema: "Menu",
                table: "MenuCategory",
                columns: new[] { "BranchId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Order_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Order", "MenuCategoryId" },
                unique: true);
        }
    }
}
