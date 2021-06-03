using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class FixingRestaurantTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantPhone_Restaruant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Restaruant_RestaurantID",
                schema: "Securities",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaruant",
                schema: "Securities",
                table: "Restaruant");

            migrationBuilder.RenameTable(
                name: "Restaruant",
                schema: "Securities",
                newName: "Restaurant",
                newSchema: "Securities");

            migrationBuilder.RenameIndex(
                name: "IX_Restaruant_Name",
                schema: "Securities",
                table: "Restaurant",
                newName: "IX_Restaurant_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                schema: "Securities",
                table: "Restaurant",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantPhone_Restaurant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone",
                column: "RestaruantID",
                principalSchema: "Securities",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Restaurant_RestaurantID",
                schema: "Securities",
                table: "User",
                column: "RestaurantID",
                principalSchema: "Securities",
                principalTable: "Restaurant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantPhone_Restaurant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Restaurant_RestaurantID",
                schema: "Securities",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                schema: "Securities",
                table: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                schema: "Securities",
                newName: "Restaruant",
                newSchema: "Securities");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_Name",
                schema: "Securities",
                table: "Restaruant",
                newName: "IX_Restaruant_Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaruant",
                schema: "Securities",
                table: "Restaruant",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantPhone_Restaruant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone",
                column: "RestaruantID",
                principalSchema: "Securities",
                principalTable: "Restaruant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

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
    }
}
