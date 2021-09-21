using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class RenamindineInToWithoutReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableXDineIn",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DineIn",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DineInState",
                schema: "Order");

            migrationBuilder.CreateTable(
                name: "WithoutReserveState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithoutReserveState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WithoutReserve",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    WithoutReserveStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithoutReserve", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_WithoutReserveState_WithoutReserveStateID",
                        column: x => x.WithoutReserveStateID,
                        principalSchema: "Order",
                        principalTable: "WithoutReserveState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXWithoutReserve",
                schema: "Order",
                columns: table => new
                {
                    WithoutReserveID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXWithoutReserve", x => new { x.WithoutReserveID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_WithoutReserve_WithoutReserveID",
                        column: x => x.WithoutReserveID,
                        principalSchema: "Order",
                        principalTable: "WithoutReserve",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TableXWithoutReserve_TableID",
                schema: "Order",
                table: "TableXWithoutReserve",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_WithoutReserve_OrderID",
                schema: "Order",
                table: "WithoutReserve",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WithoutReserve_WithoutReserveStateID",
                schema: "Order",
                table: "WithoutReserve",
                column: "WithoutReserveStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TableXWithoutReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "WithoutReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "WithoutReserveState",
                schema: "Order");

            migrationBuilder.CreateTable(
                name: "DineInState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DineInState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DineIn",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchID = table.Column<int>(type: "int", nullable: false),
                    DinerInStateID = table.Column<short>(type: "smallint", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DineIn", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DineIn_DineInState_DinerInStateID",
                        column: x => x.DinerInStateID,
                        principalSchema: "Order",
                        principalTable: "DineInState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DineIn_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXDineIn",
                schema: "Order",
                columns: table => new
                {
                    DineInID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXDineIn", x => new { x.DineInID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXDineIn_DineIn_DineInID",
                        column: x => x.DineInID,
                        principalSchema: "Order",
                        principalTable: "DineIn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXDineIn_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DineIn_DinerInStateID",
                schema: "Order",
                table: "DineIn",
                column: "DinerInStateID");

            migrationBuilder.CreateIndex(
                name: "IX_DineIn_OrderID",
                schema: "Order",
                table: "DineIn",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TableXDineIn_TableID",
                schema: "Order",
                table: "TableXDineIn",
                column: "TableID");
        }
    }
}
