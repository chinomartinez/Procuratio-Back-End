using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class SeedingWithHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Setting",
                columns: new[] { "Id", "Constrained", "DataType", "Description", "MaxValue", "MinValue" },
                values: new object[] { 1, true, "boolean", "Online menu", null, null });

            migrationBuilder.InsertData(
                schema: "Restaurant",
                table: "Setting",
                columns: new[] { "Id", "Constrained", "DataType", "Description", "MaxValue", "MinValue" },
                values: new object[] { 2, true, "boolean", "Order from table", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Setting",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Restaurant",
                table: "Setting",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
