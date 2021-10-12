using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class MovingPropertieKitchenNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KitchenNote",
                schema: "Order",
                table: "Order");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                schema: "Order",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                schema: "Order",
                table: "OrderDetail");

            migrationBuilder.AddColumn<string>(
                name: "KitchenNote",
                schema: "Order",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
