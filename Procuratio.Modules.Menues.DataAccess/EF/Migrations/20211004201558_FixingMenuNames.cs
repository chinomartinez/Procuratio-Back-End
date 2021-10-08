using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class FixingMenuNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SubCategoryItem_SubCategoryItemId",
                schema: "Menu",
                table: "Item");

            migrationBuilder.DropTable(
                name: "SubCategoryItem",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "CategoryItem",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "SubCategoryItemState",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "CategoryItemState",
                schema: "Menu");

            migrationBuilder.RenameColumn(
                name: "SubCategoryItemId",
                schema: "Menu",
                table: "Item",
                newName: "ItemSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_SubCategoryItemId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_ItemSubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_SubCategoryItemId",
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ItemCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ItemSubCategoryStateId = table.Column<short>(type: "smallint", nullable: false),
                    ItemCategoryId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_ItemCategory_ItemCategoryStateId",
                schema: "Menu",
                table: "ItemCategory",
                column: "ItemCategoryStateId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "SubCategoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_SubCategoryItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Item_BranchId_Order_ItemSubCategoryId",
                schema: "Menu",
                table: "Item",
                newName: "IX_Item_BranchId_Order_SubCategoryItemId");

            migrationBuilder.CreateTable(
                name: "CategoryItemState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItemState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItemState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CategoryItemStateId = table.Column<short>(type: "smallint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryItem_CategoryItemState_CategoryItemStateId",
                        column: x => x.CategoryItemStateId,
                        principalSchema: "Menu",
                        principalTable: "CategoryItemState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItem",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SubCategoryItemStateId = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_CategoryItem_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Menu",
                        principalTable: "CategoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_SubCategoryItemState_SubCategoryItemStateId",
                        column: x => x.SubCategoryItemStateId,
                        principalSchema: "Menu",
                        principalTable: "SubCategoryItemState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryItemStateId",
                schema: "Menu",
                table: "CategoryItem",
                column: "CategoryItemStateId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_CategoryId",
                schema: "Menu",
                table: "SubCategoryItem",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_SubCategoryItemStateId",
                schema: "Menu",
                table: "SubCategoryItem",
                column: "SubCategoryItemStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SubCategoryItem_SubCategoryItemId",
                schema: "Menu",
                table: "Item",
                column: "SubCategoryItemId",
                principalSchema: "Menu",
                principalTable: "SubCategoryItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
