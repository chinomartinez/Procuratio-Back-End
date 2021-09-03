using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class RenamingDineInPKColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableXDineIn_DineIn_DinnerInID",
                schema: "Order",
                table: "TableXDineIn");

            migrationBuilder.RenameColumn(
                name: "DinnerInID",
                schema: "Order",
                table: "TableXDineIn",
                newName: "DineInID");

            migrationBuilder.AddForeignKey(
                name: "FK_TableXDineIn_DineIn_DineInID",
                schema: "Order",
                table: "TableXDineIn",
                column: "DineInID",
                principalSchema: "Order",
                principalTable: "DineIn",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableXDineIn_DineIn_DineInID",
                schema: "Order",
                table: "TableXDineIn");

            migrationBuilder.RenameColumn(
                name: "DineInID",
                schema: "Order",
                table: "TableXDineIn",
                newName: "DinnerInID");

            migrationBuilder.AddForeignKey(
                name: "FK_TableXDineIn_DineIn_DinnerInID",
                schema: "Order",
                table: "TableXDineIn",
                column: "DinnerInID",
                principalSchema: "Order",
                principalTable: "DineIn",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
