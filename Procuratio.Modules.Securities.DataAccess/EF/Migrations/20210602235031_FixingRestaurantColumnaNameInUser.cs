using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class FixingRestaurantColumnaNameInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Restaruant_RestaruantID",
                schema: "Securities",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RestaruantID",
                schema: "Securities",
                table: "User",
                newName: "RestaurantID");

            migrationBuilder.RenameIndex(
                name: "IX_User_RestaruantID_UserName_UserSurname",
                schema: "Securities",
                table: "User",
                newName: "IX_User_RestaurantID_UserName_UserSurname");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Securities",
                table: "User",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_RestaurantID_UserName_PasswordHash",
                schema: "Securities",
                table: "User",
                columns: new[] { "RestaurantID", "UserName", "PasswordHash" },
                unique: true,
                filter: "[PasswordHash] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Restaruant_RestaurantID",
                schema: "Securities",
                table: "User",
                column: "RestaurantID",
                principalSchema: "Securities",
                principalTable: "Restaruant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Restaruant_RestaurantID",
                schema: "Securities",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_RestaurantID_UserName_PasswordHash",
                schema: "Securities",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                schema: "Securities",
                table: "User",
                newName: "RestaruantID");

            migrationBuilder.RenameIndex(
                name: "IX_User_RestaurantID_UserName_UserSurname",
                schema: "Securities",
                table: "User",
                newName: "IX_User_RestaruantID_UserName_UserSurname");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                schema: "Securities",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Restaruant_RestaruantID",
                schema: "Securities",
                table: "User",
                column: "RestaruantID",
                principalSchema: "Securities",
                principalTable: "Restaruant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
