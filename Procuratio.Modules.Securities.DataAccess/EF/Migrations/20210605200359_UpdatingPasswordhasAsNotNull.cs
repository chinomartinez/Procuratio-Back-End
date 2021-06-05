using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class UpdatingPasswordhasAsNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Securities",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserName",
                schema: "Securities",
                table: "User",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserName",
                schema: "Securities",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Securities",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
