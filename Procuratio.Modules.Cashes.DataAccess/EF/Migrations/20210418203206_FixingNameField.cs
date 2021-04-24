using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Migrations
{
    public partial class FixingNameField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Cashes",
                table: "MovementType",
                newName: "MovementTypeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Cashes",
                table: "MountType",
                newName: "MountTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovementTypeName",
                schema: "Cashes",
                table: "MovementType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MountTypeName",
                schema: "Cashes",
                table: "MountType",
                newName: "Name");
        }
    }
}
