using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class RefactoringTableIntermediatelyRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableXReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableXWithoutReserve",
                schema: "Order");

            migrationBuilder.CreateTable(
                name: "TableXOrder",
                schema: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXOrder", x => new { x.OrderId, x.TableId });
                    table.ForeignKey(
                        name: "FK_TableXOrder_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXOrder_Table_TableId",
                        column: x => x.TableId,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableXOrder_TableId",
                schema: "Order",
                table: "TableXOrder",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableXOrder",
                schema: "Order");

            migrationBuilder.CreateTable(
                name: "TableXReserve",
                schema: "Order",
                columns: table => new
                {
                    ReserveId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXReserve", x => new { x.ReserveId, x.TableId });
                    table.ForeignKey(
                        name: "FK_TableXReserve_Reserve_ReserveId",
                        column: x => x.ReserveId,
                        principalSchema: "Order",
                        principalTable: "Reserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXReserve_Table_TableId",
                        column: x => x.TableId,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXWithoutReserve",
                schema: "Order",
                columns: table => new
                {
                    WithoutReserveId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXWithoutReserve", x => new { x.WithoutReserveId, x.TableId });
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_Table_TableId",
                        column: x => x.TableId,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_WithoutReserve_WithoutReserveId",
                        column: x => x.WithoutReserveId,
                        principalSchema: "Order",
                        principalTable: "WithoutReserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableXReserve_TableId",
                schema: "Order",
                table: "TableXReserve",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_TableXWithoutReserve_TableId",
                schema: "Order",
                table: "TableXWithoutReserve",
                column: "TableId");
        }
    }
}
