using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Security.DataAccess.EF.Migrations
{
    public partial class RemovingBranchIdFromUserXRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                schema: "Security",
                table: "UserXRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                schema: "Security",
                table: "UserXRole",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
