using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class DeletingMeasure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Measure",
                schema: "Menues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Measure",
                schema: "Menues",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    MeasureName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.ID);
                });
        }
    }
}
