using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class Order_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "DeliveryState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReserveState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TakeAwayState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAwayState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithoutReserveState",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithoutReserveState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KitchenNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStateID = table.Column<short>(type: "smallint", nullable: false),
                    WaiterID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateID",
                        column: x => x.OrderStateID,
                        principalSchema: "Order",
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TableStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_TableState_TableStateID",
                        column: x => x.TableStateID,
                        principalSchema: "Order",
                        principalTable: "TableState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinyDirection = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    DeliveryStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryState_DeliveryStateID",
                        column: x => x.DeliveryStateID,
                        principalSchema: "Order",
                        principalTable: "DeliveryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityInKitchen = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDiners = table.Column<short>(type: "smallint", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ReserveStateID = table.Column<short>(type: "smallint", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserve_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_ReserveState_ReserveStateID",
                        column: x => x.ReserveStateID,
                        principalSchema: "Order",
                        principalTable: "ReserveState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakeAway",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    TakeAwayStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAway", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakeAway_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeAway_TakeAwayState_TakeAwayStateID",
                        column: x => x.TakeAwayStateID,
                        principalSchema: "Order",
                        principalTable: "TakeAwayState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithoutReserve",
                schema: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    WithoutReserveStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithoutReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_WithoutReserveState_WithoutReserveStateID",
                        column: x => x.WithoutReserveStateID,
                        principalSchema: "Order",
                        principalTable: "WithoutReserveState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXReserve",
                schema: "Order",
                columns: table => new
                {
                    ReserveID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXReserve", x => new { x.ReserveID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXReserve_Reserve_ReserveID",
                        column: x => x.ReserveID,
                        principalSchema: "Order",
                        principalTable: "Reserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXReserve_Table_TableID",
                        column: x => x.TableID,
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
                    WithoutReserveID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXWithoutReserve", x => new { x.WithoutReserveID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXWithoutReserve_WithoutReserve_WithoutReserveID",
                        column: x => x.WithoutReserveID,
                        principalSchema: "Order",
                        principalTable: "WithoutReserve",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryStateID",
                schema: "Order",
                table: "Delivery",
                column: "DeliveryStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_OrderID",
                schema: "Order",
                table: "Delivery",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateID",
                schema: "Order",
                table: "Order",
                column: "OrderStateID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                schema: "Order",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_OrderID",
                schema: "Order",
                table: "Reserve",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_ReserveStateID",
                schema: "Order",
                table: "Reserve",
                column: "ReserveStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableStateID",
                schema: "Order",
                table: "Table",
                column: "TableStateID");

            migrationBuilder.CreateIndex(
                name: "IX_TableXReserve_TableID",
                schema: "Order",
                table: "TableXReserve",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_TableXWithoutReserve_TableID",
                schema: "Order",
                table: "TableXWithoutReserve",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_OrderID",
                schema: "Order",
                table: "TakeAway",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_TakeAwayStateID",
                schema: "Order",
                table: "TakeAway",
                column: "TakeAwayStateID");

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
                name: "Delivery",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableXReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableXWithoutReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TakeAway",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DeliveryState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Reserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Table",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "WithoutReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TakeAwayState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "ReserveState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "WithoutReserveState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "OrderState",
                schema: "Order");
        }
    }
}
