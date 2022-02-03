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
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PriceInsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    PriceOutsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ItemStateId = table.Column<short>(type: "smallint", nullable: false),
                    MenuSubcategoryId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Item_MenuSubCategory_MenuSubcategoryId",
                        column: x => x.MenuSubcategoryId,
                        principalSchema: "Menu",
                        principalTable: "MenuSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Name",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_BranchId_Order_MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                columns: new[] { "BranchId", "Order", "MenuSubcategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemStateId",
                schema: "Menu",
                table: "Item",
                column: "ItemStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_MenuSubcategoryId",
                schema: "Menu",
                table: "Item",
                column: "MenuSubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuCategory_BranchId_Name",
                schema: "Menu",
                table: "MenuCategory",
                columns: new[] { "BranchId", "Name" },
                unique: true);

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
        }
    }
}
