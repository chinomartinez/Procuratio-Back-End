using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class AddingUserState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "UserStateID",
                schema: "Securities",
                table: "User",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateTable(
                name: "UserState",
                schema: "Securities",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserState", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserStateID",
                schema: "Securities",
                table: "User",
                column: "UserStateID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserState_UserStateID",
                schema: "Securities",
                table: "User",
                column: "UserStateID",
                principalSchema: "Securities",
                principalTable: "UserState",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserState_UserStateID",
                schema: "Securities",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserState",
                schema: "Securities");

            migrationBuilder.DropIndex(
                name: "IX_User_UserStateID",
                schema: "Securities",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserStateID",
                schema: "Securities",
                table: "User");
        }
    }
}
