using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class Orders_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Orders");

            migrationBuilder.CreateTable(
                name: "DeliveryState",
                schema: "Orders",
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
                schema: "Orders",
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
                schema: "Orders",
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
                schema: "Orders",
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
                schema: "Orders",
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
                schema: "Orders",
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
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "OrderState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "TableState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "DeliveryState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Orders",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DineIn",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "DineInState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DineIn_Order_OrderID",
                        column: x => x.OrderID,
                        principalSchema: "Orders",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reserve",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_ReserveState_ReserveStateID",
                        column: x => x.ReserveStateID,
                        principalSchema: "Orders",
                        principalTable: "ReserveState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TakeAway",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeAway_TakeAwayState_TakeAwayStateID",
                        column: x => x.TakeAwayStateID,
                        principalSchema: "Orders",
                        principalTable: "TakeAwayState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXDineIn",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "DineIn",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXDineIn_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Orders",
                        principalTable: "Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TableXReserve",
                schema: "Orders",
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
                        principalSchema: "Orders",
                        principalTable: "Reserve",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TableXReserve_Table_TableID",
                        column: x => x.TableID,
                        principalSchema: "Orders",
                        principalTable: "Table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_DeliveryStateID",
                schema: "Orders",
                table: "Delivery",
                column: "DeliveryStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_OrderID",
                schema: "Orders",
                table: "Delivery",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DineIn_DinerInStateID",
                schema: "Orders",
                table: "DineIn",
                column: "DinerInStateID");

            migrationBuilder.CreateIndex(
                name: "IX_DineIn_OrderID",
                schema: "Orders",
                table: "DineIn",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateID",
                schema: "Orders",
                table: "Order",
                column: "OrderStateID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                schema: "Orders",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_OrderID",
                schema: "Orders",
                table: "Reserve",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_ReserveStateID",
                schema: "Orders",
                table: "Reserve",
                column: "ReserveStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableStateID",
                schema: "Orders",
                table: "Table",
                column: "TableStateID");

            migrationBuilder.CreateIndex(
                name: "IX_TableXDineIn_TableID",
                schema: "Orders",
                table: "TableXDineIn",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_TableXReserve_TableID",
                schema: "Orders",
                table: "TableXReserve",
                column: "TableID");

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_OrderID",
                schema: "Orders",
                table: "TakeAway",
                column: "OrderID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_TakeAwayStateID",
                schema: "Orders",
                table: "TakeAway",
                column: "TakeAwayStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "TableXDineIn",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "TableXReserve",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "TakeAway",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryState",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "DineIn",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Reserve",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Table",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "TakeAwayState",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "DineInState",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "ReserveState",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "TableState",
                schema: "Orders");

            migrationBuilder.DropTable(
                name: "OrderState",
                schema: "Orders");
        }
    }
}
