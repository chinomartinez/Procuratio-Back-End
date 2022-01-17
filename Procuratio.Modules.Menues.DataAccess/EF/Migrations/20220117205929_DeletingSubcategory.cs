using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class DeletingSubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MenuSubCategory_MenuSubcategoryId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropTable(
                name: "MenuSubCategory",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuSubCategoryState",
                schema: "Menu");

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
                name: "FK_Item_MenuCategory_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                column: "MenuCategoryId",
                principalSchema: "Menu",
                principalTable: "MenuCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MenuCategory_MenuCategoryId",
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

            migrationBuilder.CreateTable(
                name: "MenuSubCategoryState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSubCategoryState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuSubCategory",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    MenuCategoryId = table.Column<int>(type: "int", nullable: false),
                    MenuSubCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuSubCategory_MenuCategory_MenuCategoryId",
                        column: x => x.MenuCategoryId,
                        principalSchema: "Menu",
                        principalTable: "MenuCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSubCategory_MenuSubCategoryState_MenuSubCategoryStateId",
                        column: x => x.MenuSubCategoryStateId,
                        principalSchema: "Menu",
                        principalTable: "MenuSubCategoryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuSubCategory",
                columns: new[] { "BranchId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCategory_BranchId_Order_MenuCategoryId",
                schema: "Menu",
                table: "MenuSubCategory",
                columns: new[] { "BranchId", "Order", "MenuCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCategory_MenuCategoryId",
                schema: "Menu",
                table: "MenuSubCategory",
                column: "MenuCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSubCategory_MenuSubCategoryStateId",
                schema: "Menu",
                table: "MenuSubCategory",
                column: "MenuSubCategoryStateId");

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
    }
}
