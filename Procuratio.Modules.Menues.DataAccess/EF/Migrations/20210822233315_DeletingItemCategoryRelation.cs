using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class DeletingItemCategoryRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_CategoryItem_CategoryItemID",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_CategoryItemID",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CategoryItemID",
                schema: "Menu",
                table: "Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryItemID",
                schema: "Menu",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryItemID",
                schema: "Menu",
                table: "Item",
                column: "CategoryItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_CategoryItem_CategoryItemID",
                schema: "Menu",
                table: "Item",
                column: "CategoryItemID",
                principalSchema: "Menu",
                principalTable: "CategoryItem",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
