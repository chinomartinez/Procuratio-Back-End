using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
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
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryState", x => x.ID);
                });

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
                name: "OrderState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ReserveState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReserveState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TableState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TakeAwayState",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAwayState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KitchenNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderStateID = table.Column<short>(type: "smallint", nullable: false),
                    ChefID = table.Column<int>(type: "int", nullable: false),
                    WaiterID = table.Column<int>(type: "int", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateID",
                        column: x => x.OrderStateID,
                        principalSchema: "Order",
                        principalTable: "OrderState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<short>(type: "smallint", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TableStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Table_TableState_TableStateID",
                        column: x => x.TableStateID,
                        principalSchema: "Order",
                        principalTable: "TableState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinyDirection = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    DeliveryStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryState_DeliveryStateID",
                        column: x => x.DeliveryStateID,
                        principalSchema: "Order",
                        principalTable: "DeliveryState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DineIn",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    DinerInStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
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
                name: "OrderDetail",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityInKitchen = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfDiners = table.Column<short>(type: "smallint", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ReserveStateID = table.Column<short>(type: "smallint", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reserve_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_ReserveState_ReserveStateID",
                        column: x => x.ReserveStateID,
                        principalSchema: "Order",
                        principalTable: "ReserveState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakeAway",
                schema: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    TakeAwayStateID = table.Column<short>(type: "smallint", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAway", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TakeAway_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeAway_TakeAwayState_TakeAwayStateID",
                        column: x => x.TakeAwayStateID,
                        principalSchema: "Order",
                        principalTable: "TakeAwayState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXDineIn",
                schema: "Order",
                columns: table => new
                {
                    DinnerInID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXDineIn", x => new { x.DinnerInID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXDineIn_DineIn_DinnerInID",
                        column: x => x.DinnerInID,
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

            migrationBuilder.CreateTable(
                name: "TableXReserve",
                schema: "Order",
                columns: table => new
                {
                    ReserveID = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<int>(type: "int", nullable: false),
                    BranchID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableXReserve", x => new { x.ReserveID, x.TableID });
                    table.ForeignKey(
                        name: "FK_TableXReserve_Reserve_ReserveID",
                        column: x => x.ReserveID,
                        principalSchema: "Order",
                        principalTable: "Reserve",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXReserve_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Order",
                        principalTable: "Table",
                        principalColumn: "ID",
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
                name: "IX_TableXDineIn_TableID",
                schema: "Order",
                table: "TableXDineIn",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_TableXReserve_TableID",
                schema: "Order",
                table: "TableXReserve",
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
                name: "TableXDineIn",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableXReserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TakeAway",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DeliveryState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DineIn",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Reserve",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Table",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TakeAwayState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "DineInState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "ReserveState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "TableState",
                schema: "Order");

            migrationBuilder.DropTable(
                name: "OrderState",
                schema: "Order");
        }
    }
}
