using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class AddingPasswordToWithoutReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "Order",
                table: "WithoutReserve",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "Order",
                table: "WithoutReserve");
        }
    }
}
