using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class RelationBetweenUserAndRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "Securities",
                table: "Restaruant",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaruant_UserId",
                schema: "Securities",
                table: "Restaruant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaruant_User_UserId",
                schema: "Securities",
                table: "Restaruant",
                column: "UserId",
                principalSchema: "Securities",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaruant_User_UserId",
                schema: "Securities",
                table: "Restaruant");

            migrationBuilder.DropIndex(
                name: "IX_Restaruant_UserId",
                schema: "Securities",
                table: "Restaruant");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Securities",
                table: "Restaruant");
        }
    }
}
