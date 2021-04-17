using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class DeletingUserIDFromSpecificsOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_TableState_TableStateID",
                schema: "Orders",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Orders",
                table: "TakeAway");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Orders",
                table: "Reserve");

            migrationBuilder.DropColumn(
                name: "UserID",
                schema: "Orders",
                table: "DinerIn");

            migrationBuilder.AlterColumn<int>(
                name: "TableStateID",
                schema: "Orders",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WaiterID",
                schema: "Orders",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_TableState_TableStateID",
                schema: "Orders",
                table: "Table",
                column: "TableStateID",
                principalSchema: "Orders",
                principalTable: "TableState",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Table_TableState_TableStateID",
                schema: "Orders",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "WaiterID",
                schema: "Orders",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "Orders",
                table: "TakeAway",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TableStateID",
                schema: "Orders",
                table: "Table",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "Orders",
                table: "Reserve",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                schema: "Orders",
                table: "DinerIn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Table_TableState_TableStateID",
                schema: "Orders",
                table: "Table",
                column: "TableStateID",
                principalSchema: "Orders",
                principalTable: "TableState",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
