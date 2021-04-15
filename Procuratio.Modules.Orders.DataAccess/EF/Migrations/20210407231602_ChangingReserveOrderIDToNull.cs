using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class ChangingReserveOrderIDToNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Order_OrderID",
                schema: "Orders",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_OrderID",
                schema: "Orders",
                table: "Reserve");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                schema: "Orders",
                table: "Reserve",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_OrderID",
                schema: "Orders",
                table: "Reserve",
                column: "OrderID",
                unique: true,
                filter: "[OrderID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Order_OrderID",
                schema: "Orders",
                table: "Reserve",
                column: "OrderID",
                principalSchema: "Orders",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserve_Order_OrderID",
                schema: "Orders",
                table: "Reserve");

            migrationBuilder.DropIndex(
                name: "IX_Reserve_OrderID",
                schema: "Orders",
                table: "Reserve");

            migrationBuilder.AlterColumn<int>(
                name: "OrderID",
                schema: "Orders",
                table: "Reserve",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserve_OrderID",
                schema: "Orders",
                table: "Reserve",
                column: "OrderID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserve_Order_OrderID",
                schema: "Orders",
                table: "Reserve",
                column: "OrderID",
                principalSchema: "Orders",
                principalTable: "Order",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
