using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menu.DataAccess.EF.Migrations
{
    public partial class SeedingWithHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Menu",
                table: "ItemState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Disponible" },
                    { (short)2, "Eliminado" }
                });

            migrationBuilder.InsertData(
                schema: "Menu",
                table: "MenuCategoryState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Disponible" },
                    { (short)2, "Eliminado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Menu",
                table: "ItemState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Menu",
                table: "ItemState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Menu",
                table: "MenuCategoryState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Menu",
                table: "MenuCategoryState",
                keyColumn: "Id",
                keyValue: (short)2);
        }
    }
}
