using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class DeletingItemAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemAttributeXItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemAttribute",
                schema: "Menues");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                schema: "Menues",
                table: "Item",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceInsideRestaurant",
                schema: "Menues",
                table: "Item",
                type: "decimal(19,4)",
                precision: 19,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceOutsideRestaurant",
                schema: "Menues",
                table: "Item",
                type: "decimal(19,4)",
                precision: 19,
                scale: 4,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                schema: "Menues",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PriceInsideRestaurant",
                schema: "Menues",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "PriceOutsideRestaurant",
                schema: "Menues",
                table: "Item");

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
                name: "IX_ItemAttribute_MeasureID",
                schema: "Menues",
                table: "ItemAttribute",
                column: "MeasureID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttributeXItem_ItemID",
                schema: "Menues",
                table: "ItemAttributeXItem",
                column: "ItemID");
        }
    }
}
