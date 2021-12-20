using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Security.DataAccess.EF.Migrations
{
    public partial class AddingProfilePictureToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                schema: "Security",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Security",
                table: "User");
        }
    }
}
