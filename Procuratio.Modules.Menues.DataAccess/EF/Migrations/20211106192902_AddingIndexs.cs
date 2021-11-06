using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class AddingIndexs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuSubCategory",
                columns: new[] { "BranchId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuCategory",
                columns: new[] { "BranchId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Name",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MenuSubCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuSubCategory");

            migrationBuilder.DropIndex(
                name: "IX_MenuCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuCategory");

            migrationBuilder.DropIndex(
                name: "IX_Item_BranchId_Name",
                schema: "Menu",
                table: "Item");
        }
    }
}
