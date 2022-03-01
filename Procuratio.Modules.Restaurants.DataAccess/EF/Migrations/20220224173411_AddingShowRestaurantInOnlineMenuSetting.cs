using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class AddingShowRestaurantInOnlineMenuSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Setting",
                columns: new[] { "Id", "Constrained", "DataType", "Description", "MaxValue", "MinValue" },
                values: new object[] { 3, true, "boolean", "Show Restaurant In Online Menu", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Setting",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
