using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class updatingStatesTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "TakeAwayState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "TableState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "ReserveState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "OrderState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "DinerInState",
                newName: "StateName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Orders",
                table: "DeliveryState",
                newName: "StateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "TakeAwayState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "TableState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "ReserveState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "OrderState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "DinerInState",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Orders",
                table: "DeliveryState",
                newName: "Name");
        }
    }
}
