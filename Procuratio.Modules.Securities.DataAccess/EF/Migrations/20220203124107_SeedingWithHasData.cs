using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Security.DataAccess.EF.Migrations
{
    public partial class SeedingWithHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Security",
                table: "UserState",
                columns: new[] { "Id", "StateName" },
                values: new object[] { (short)1, "Activo" });

            migrationBuilder.InsertData(
                schema: "Security",
                table: "UserState",
                columns: new[] { "Id", "StateName" },
                values: new object[] { (short)2, "Dado de baja" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Security",
                table: "UserState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Security",
                table: "UserState",
                keyColumn: "Id",
                keyValue: (short)2);
        }
    }
}
