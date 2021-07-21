using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class Menu_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menu");

            migrationBuilder.CreateTable(
                name: "CategoryItemState",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemState",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItemState",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryItem_CategoryItemState_CategoryItemStateID",
                        column: x => x.CategoryItemStateID,
                        principalSchema: "Menu",
                        principalTable: "CategoryItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItem",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SubCategoryItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_CategoryItem_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "Menu",
                        principalTable: "CategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_SubCategoryItemState_SubCategoryItemStateID",
                        column: x => x.SubCategoryItemStateID,
                        principalSchema: "Menu",
                        principalTable: "SubCategoryItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Menu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ForKitchen = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PriceInsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    PriceOutsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    SubCategoryItemID = table.Column<int>(type: "int", nullable: false),
                    CategoryItemID = table.Column<int>(type: "int", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_CategoryItem_CategoryItemID",
                        column: x => x.CategoryItemID,
                        principalSchema: "Menu",
                        principalTable: "CategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemState_ItemStateID",
                        column: x => x.ItemStateID,
                        principalSchema: "Menu",
                        principalTable: "ItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_SubCategoryItem_SubCategoryItemID",
                        column: x => x.SubCategoryItemID,
                        principalSchema: "Menu",
                        principalTable: "SubCategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryItemStateID",
                schema: "Menu",
                table: "CategoryItem",
                column: "CategoryItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryItemID",
                schema: "Menu",
                table: "Item",
                column: "CategoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemStateID",
                schema: "Menu",
                table: "Item",
                column: "ItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubCategoryItemID",
                schema: "Menu",
                table: "Item",
                column: "SubCategoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_CategoryID",
                schema: "Menu",
                table: "SubCategoryItem",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_SubCategoryItemStateID",
                schema: "Menu",
                table: "SubCategoryItem",
                column: "SubCategoryItemStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item",
                schema: "Menu");

            migrationBuilder.DropTable(
                name: "ItemState",
                schema: "Menu");

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
        }
    }
}
