using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class ItemOrderIndexFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Item_BranchId_Order",
                schema: "Menu",
                table: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Order_SubCategoryItemId",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Order", "SubCategoryItemId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Item_BranchId_Order_SubCategoryItemId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Order",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Order" },
                unique: true);
        }
    }
}
