using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                    OrderStateId = table.Column<short>(type: "smallint", nullable: false),
                    WaiterId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateId",
                        column: x => x.OrderStateId,
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
                    TableStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_TableState_TableStateId",
                        column: x => x.TableStateId,
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
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DeliveryStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Delivery_DeliveryState_DeliveryStateId",
                        column: x => x.DeliveryStateId,
                        principalSchema: "Order",
                        principalTable: "DeliveryState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Order_OrderId",
                        column: x => x.OrderId,
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
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
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
                    OrderId = table.Column<int>(type: "int", nullable: true),
                    ReserveStateId = table.Column<short>(type: "smallint", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserve_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reserve_ReserveState_ReserveStateId",
                        column: x => x.ReserveStateId,
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
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TakeAwayStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakeAway", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TakeAway_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TakeAway_TakeAwayState_TakeAwayStateId",
                        column: x => x.TakeAwayStateId,
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
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    WithoutReserveStateId = table.Column<short>(type: "smallint", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithoutReserve", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Order",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithoutReserve_WithoutReserveState_WithoutReserveStateId",
                        column: x => x.WithoutReserveStateId,
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
                name: "IX_Delivery_DeliveryStateId",
                schema: "Order",
                table: "Delivery",
                column: "DeliveryStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_OrderId",
                schema: "Order",
                table: "Delivery",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateId",
                schema: "Order",
                table: "Order",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "Order",
                table: "OrderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_OrderId",
                schema: "Order",
                table: "Reserve",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_ReserveStateId",
                schema: "Order",
                table: "Reserve",
                column: "ReserveStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_TableStateId",
                schema: "Order",
                table: "Table",
                column: "TableStateId");

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

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_OrderId",
                schema: "Order",
                table: "TakeAway",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TakeAway_TakeAwayStateId",
                schema: "Order",
                table: "TakeAway",
                column: "TakeAwayStateId");

            migrationBuilder.CreateIndex(
                name: "IX_WithoutReserve_OrderId",
                schema: "Order",
                table: "WithoutReserve",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WithoutReserve_WithoutReserveStateId",
                schema: "Order",
                table: "WithoutReserve",
                column: "WithoutReserveStateId");
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
