using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class FixingRestaurantSettingsId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UnconstrainedValue",
                schema: "Restaurant",
                table: "BranchSetting",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UnconstrainedValue",
                schema: "Restaurant",
                table: "BranchSetting",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
