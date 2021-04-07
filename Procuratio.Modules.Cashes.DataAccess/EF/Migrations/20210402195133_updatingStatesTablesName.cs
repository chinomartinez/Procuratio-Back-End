using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Migrations
{
    public partial class updatingStatesTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Cashes",
                table: "CashState",
                newName: "StateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Cashes",
                table: "CashState",
                newName: "Name");
        }
    }
}
