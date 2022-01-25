using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class AddingAndRemovingFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Withdrawn",
                schema: "Restaurant",
                table: "Branch");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Restaurant",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Restaurant",
                table: "Restaurant");

            migrationBuilder.AddColumn<int>(
                name: "Withdrawn",
                schema: "Restaurant",
                table: "Branch",
                type: "int",
                nullable: true);
        }
    }
}
