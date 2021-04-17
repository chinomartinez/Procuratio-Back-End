using Microsoft.EntityFrameworkCore.Migrations;
using System;

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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExtraIngredientState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredientState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ExtraIngredientXItemState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredientXItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemXPromotionState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemXPromotionState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PromotionState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItemState",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryItemStateID = table.Column<int>(type: "int", nullable: false),
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
                name: "ExtraIngredient",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MenuPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DinerInPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TakeAwayPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ExtraIngredientStateID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ExtraIngredient_ExtraIngredientState_ExtraIngredientStateID",
                        column: x => x.ExtraIngredientStateID,
                        principalSchema: "Menues",
                        principalTable: "ExtraIngredientState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotion",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    MenuPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DinerInPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TakeAwayPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PromotionOrder = table.Column<int>(type: "int", nullable: false),
                    PromotionStateID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Promotion_PromotionState_PromotionStateID",
                        column: x => x.PromotionStateID,
                        principalSchema: "Menues",
                        principalTable: "PromotionState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryItem",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    SubCategoryItemOrder = table.Column<int>(type: "int", nullable: false),
                    SubCategoryItemStateID = table.Column<int>(type: "int", nullable: false),
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
                name: "PromotionDayOfWeek",
                schema: "Menues",
                columns: table => new
                {
                    DayNumber = table.Column<int>(type: "int", nullable: false),
                    PromotionID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDayOfWeek", x => new { x.PromotionID, x.DayNumber });
                    table.ForeignKey(
                        name: "FK_PromotionDayOfWeek_Promotion_PromotionID",
                        column: x => x.PromotionID,
                        principalSchema: "Menues",
                        principalTable: "Promotion",
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
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    MenuPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DinerInPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    TakeAwayPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    ForKitchen = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ItemOrder = table.Column<int>(type: "int", nullable: false),
                    ItemStateID = table.Column<int>(type: "int", nullable: false),
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
                name: "PromotionDayOfWeekTimeRange",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Begin = table.Column<TimeSpan>(type: "time", nullable: false),
                    Finish = table.Column<TimeSpan>(type: "time", nullable: false),
                    DayOfweekID = table.Column<int>(type: "int", nullable: false),
                    PromotionDayOfWeekPromotionID = table.Column<int>(type: "int", nullable: true),
                    PromotionDayOfWeekDayNumber = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionDayOfWeekTimeRange", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PromotionDayOfWeekTimeRange_PromotionDayOfWeek_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                        columns: x => new { x.PromotionDayOfWeekPromotionID, x.PromotionDayOfWeekDayNumber },
                        principalSchema: "Menues",
                        principalTable: "PromotionDayOfWeek",
                        principalColumns: new[] { "PromotionID", "DayNumber" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraIngredientXItem",
                schema: "Menues",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    ExtraIngredientID = table.Column<int>(type: "int", nullable: false),
                    ExtraIngredientXItemStateID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredientXItem", x => new { x.ExtraIngredientID, x.ItemID });
                    table.ForeignKey(
                        name: "FK_ExtraIngredientXItem_ExtraIngredient_ExtraIngredientID",
                        column: x => x.ExtraIngredientID,
                        principalSchema: "Menues",
                        principalTable: "ExtraIngredient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraIngredientXItem_ExtraIngredientXItemState_ExtraIngredientXItemStateID",
                        column: x => x.ExtraIngredientXItemStateID,
                        principalSchema: "Menues",
                        principalTable: "ExtraIngredientXItemState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraIngredientXItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "Menues",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemXPromotion",
                schema: "Menues",
                columns: table => new
                {
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    PromotionID = table.Column<int>(type: "int", nullable: false),
                    ItemXPromotionOrder = table.Column<int>(type: "int", nullable: false),
                    ItemXPromotionStateID = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemXPromotion", x => new { x.ItemID, x.PromotionID });
                    table.ForeignKey(
                        name: "FK_ItemXPromotion_Item_ItemID",
                        column: x => x.ItemID,
                        principalSchema: "Menues",
                        principalTable: "Item",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemXPromotion_ItemXPromotionState_ItemXPromotionStateID",
                        column: x => x.ItemXPromotionStateID,
                        principalSchema: "Menues",
                        principalTable: "ItemXPromotionState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemXPromotion_Promotion_PromotionID",
                        column: x => x.PromotionID,
                        principalSchema: "Menues",
                        principalTable: "Promotion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_CategoryItemStateID",
                schema: "Menues",
                table: "CategoryItem",
                column: "CategoryItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraIngredient_ExtraIngredientStateID",
                schema: "Menues",
                table: "ExtraIngredient",
                column: "ExtraIngredientStateID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraIngredientXItem_ExtraIngredientXItemStateID",
                schema: "Menues",
                table: "ExtraIngredientXItem",
                column: "ExtraIngredientXItemStateID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraIngredientXItem_ItemID",
                schema: "Menues",
                table: "ExtraIngredientXItem",
                column: "ItemID");

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
                name: "IX_ItemXPromotion_ItemXPromotionStateID",
                schema: "Menues",
                table: "ItemXPromotion",
                column: "ItemXPromotionStateID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemXPromotion_PromotionID",
                schema: "Menues",
                table: "ItemXPromotion",
                column: "PromotionID");

            migrationBuilder.CreateIndex(
                name: "IX_Promotion_PromotionStateID",
                schema: "Menues",
                table: "Promotion",
                column: "PromotionStateID");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDayOfWeekTimeRange_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                columns: new[] { "PromotionDayOfWeekPromotionID", "PromotionDayOfWeekDayNumber" });

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
                name: "ExtraIngredientXItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemXPromotion",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "PromotionDayOfWeekTimeRange",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ExtraIngredient",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ExtraIngredientXItemState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemXPromotionState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "PromotionDayOfWeek",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ExtraIngredientState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "ItemState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "SubCategoryItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "Promotion",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "CategoryItem",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "SubCategoryItemState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "PromotionState",
                schema: "Menues");

            migrationBuilder.DropTable(
                name: "CategoryItemState",
                schema: "Menues");
        }
    }
}
