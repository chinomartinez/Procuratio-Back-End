using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Orders.DataAccess.EF.Migrations
{
    public partial class DeletingChefIDFromOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChefID",
                schema: "Order",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChefID",
                schema: "Order",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
