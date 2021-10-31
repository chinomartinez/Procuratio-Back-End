using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class AddingIndexToCategoryAndSubCategoryItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategory_BranchId_Order_ItemCategoryId",
                schema: "Menu",
                table: "ItemSubCategory",
                columns: new[] { "BranchId", "Order", "ItemCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_BranchId_Order",
                schema: "Menu",
                table: "ItemCategory",
                columns: new[] { "BranchId", "Order" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemSubCategory_BranchId_Order_ItemCategoryId",
                schema: "Menu",
                table: "ItemSubCategory");

            migrationBuilder.DropIndex(
                name: "IX_ItemCategory_BranchId_Order",
                schema: "Menu",
                table: "ItemCategory");
        }
    }
}
