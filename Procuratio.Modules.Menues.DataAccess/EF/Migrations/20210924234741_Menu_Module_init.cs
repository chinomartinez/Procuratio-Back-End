using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
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
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemState",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemState", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryItemStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    SubCategoryItemStateId = table.Column<short>(type: "smallint", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ForKitchen = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PriceInsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    PriceOutsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ItemStateId = table.Column<short>(type: "smallint", nullable: false),
                    SubCategoryItemId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_ItemState_ItemStateId",
                        column: x => x.ItemStateId,
                        principalSchema: "Menu",
                        principalTable: "ItemState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_SubCategoryItem_SubCategoryItemId",
                        column: x => x.SubCategoryItemId,
                        principalSchema: "Menu",
                        principalTable: "SubCategoryItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryItemStateId",
                schema: "Menu",
                table: "CategoryItem",
                column: "CategoryItemStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemStateId",
                schema: "Menu",
                table: "Item",
                column: "ItemStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubCategoryItemId",
                schema: "Menu",
                table: "Item",
                column: "SubCategoryItemId");

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
