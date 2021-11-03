using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class RenamingItemCategoryAndItemSubcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_ItemSubCategory_ItemSubCategoryId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropTable(
                name: "ItemSubCategory",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "ItemCategory",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "ItemSubCategoryState",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "ItemCategoryState",
                schema: "Menu");

            migrationBuilder.RenameColumn(
                name: "ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "MenuCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_MenuCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_BranchId_Order_MenuCategoryId");

            migrationBuilder.CreateTable(
                name: "MenuCategoryState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategoryState", x => x.Id);
                });

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
                name: "MenuCategory",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MenuCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCategory_MenuCategoryState_MenuCategoryStateId",
                        column: x => x.MenuCategoryStateId,
                        principalSchema: "Menu",
                        principalTable: "MenuCategoryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuSubCategory",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    MenuSubCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    MenuCategoryId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_MenuCategory_BranchId_Order",
                schema: "Menu",
                table: "MenuCategory",
                columns: new[] { "BranchId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_MenuCategoryStateId",
                schema: "Menu",
                table: "MenuCategory",
                column: "MenuCategoryStateId");

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
                name: "FK_Item_MenuSubCategory_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                column: "MenuCategoryId",
                principalSchema: "Menu",
                principalTable: "MenuSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_MenuSubCategory_MenuCategoryId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropTable(
                name: "MenuSubCategory",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuCategory",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuSubCategoryState",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "MenuCategoryState",
                schema: "Menu");

            migrationBuilder.RenameColumn(
                name: "MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "ItemSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_ItemSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_MenuCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_BranchId_Order_ItemSubCategoryId");

            migrationBuilder.CreateTable(
                name: "ItemCategoryState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategoryState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubCategoryState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubCategoryState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategory",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ItemCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCategory_ItemCategoryState_ItemCategoryStateId",
                        column: x => x.ItemCategoryStateId,
                        principalSchema: "Menu",
                        principalTable: "ItemCategoryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubCategory",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    ItemSubCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubCategory_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalSchema: "Menu",
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemSubCategory_ItemSubCategoryState_ItemSubCategoryStateId",
                        column: x => x.ItemSubCategoryStateId,
                        principalSchema: "Menu",
                        principalTable: "ItemSubCategoryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_BranchId_Order",
                schema: "Menu",
                table: "ItemCategory",
                columns: new[] { "BranchId", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategory_ItemCategoryStateId",
                schema: "Menu",
                table: "ItemCategory",
                column: "ItemCategoryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategory_BranchId_Order_ItemCategoryId",
                schema: "Menu",
                table: "ItemSubCategory",
                columns: new[] { "BranchId", "Order", "ItemCategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategory_ItemCategoryId",
                schema: "Menu",
                table: "ItemSubCategory",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategory_ItemSubCategoryStateId",
                schema: "Menu",
                table: "ItemSubCategory",
                column: "ItemSubCategoryStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_ItemSubCategory_ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                column: "ItemSubCategoryId",
                principalSchema: "Menu",
                principalTable: "ItemSubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
