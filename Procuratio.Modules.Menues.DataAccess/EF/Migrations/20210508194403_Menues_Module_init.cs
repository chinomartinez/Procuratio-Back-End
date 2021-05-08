using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class Menues_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Menues");

            migrationBuilder.CreateTable(
                name: "CategoryItemState",
                schema: "Menues",
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
                schema: "Menues",
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
                name: "Measure",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    MeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItemState",
                schema: "Menues",
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
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryItem_CategoryItemState_CategoryItemStateID",
                        column: x => x.CategoryItemStateID,
                        principalSchema: "Menues",
                        principalTable: "CategoryItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttribute",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attribute = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MeasureID = table.Column<short>(type: "smallint", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttribute", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemAttribute_Measure_MeasureID",
                        column: x => x.MeasureID,
                        principalSchema: "Menues",
                        principalTable: "Measure",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItem",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubCategoryItemOrder = table.Column<int>(type: "int", nullable: false),
                    SubCategoryItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryItem", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_CategoryItem_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "Menues",
                        principalTable: "CategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryItem_SubCategoryItemState_SubCategoryItemStateID",
                        column: x => x.SubCategoryItemStateID,
                        principalSchema: "Menues",
                        principalTable: "SubCategoryItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ForKitchen = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemOrder = table.Column<int>(type: "int", nullable: false),
                    ItemStateID = table.Column<short>(type: "smallint", nullable: false),
                    CategoryItemID = table.Column<int>(type: "int", nullable: true),
                    SubCategoryItemID = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Item_CategoryItem_CategoryItemID",
                        column: x => x.CategoryItemID,
                        principalSchema: "Menues",
                        principalTable: "CategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_ItemState_ItemStateID",
                        column: x => x.ItemStateID,
                        principalSchema: "Menues",
                        principalTable: "ItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_SubCategoryItem_SubCategoryItemID",
                        column: x => x.SubCategoryItemID,
                        principalSchema: "Menues",
                        principalTable: "SubCategoryItem",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttributeXItem",
                schema: "Menues",
                columns: table => new
                {
                    ItemAttributeID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PriceInsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    PriceOutsideRestaurant = table.Column<decimal>(type: "decimal(19,4)", precision: 19, scale: 4, nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributeXItem", x => new { x.ItemAttributeID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_ItemAttributeXItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "Menues",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemAttributeXItem_ItemAttribute_ItemAttributeID",
                        column: x => x.ItemAttributeID,
                        principalSchema: "Menues",
                        principalTable: "ItemAttribute",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryItemStateID",
                schema: "Menues",
                table: "CategoryItem",
                column: "CategoryItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_CategoryItemID",
                schema: "Menues",
                table: "Item",
                column: "CategoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_ItemStateID",
                schema: "Menues",
                table: "Item",
                column: "ItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SubCategoryItemID",
                schema: "Menues",
                table: "Item",
                column: "SubCategoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttribute_MeasureID",
                schema: "Menues",
                table: "ItemAttribute",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttributeXItem_ItemID",
                schema: "Menues",
                table: "ItemAttributeXItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_CategoryID",
                schema: "Menues",
                table: "SubCategoryItem",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryItem_SubCategoryItemStateID",
                schema: "Menues",
                table: "SubCategoryItem",
                column: "SubCategoryItemStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAttributeXItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemAttribute",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "SubCategoryItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "Measure",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "CategoryItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "SubCategoryItemState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "CategoryItemState",
                schema: "Menues");
        }
    }
}
