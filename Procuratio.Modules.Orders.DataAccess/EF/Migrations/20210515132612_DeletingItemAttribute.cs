using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class DeletingItemAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemAttributeID",
                schema: "Orders",
                table: "OrderDetail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemAttributeID",
                schema: "Orders",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
