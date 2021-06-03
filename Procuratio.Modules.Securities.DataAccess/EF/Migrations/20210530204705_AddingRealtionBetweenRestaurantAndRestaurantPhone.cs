using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Securities.DataAccess.EF.Migrations
{
    public partial class AddingRealtionBetweenRestaurantAndRestaurantPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantPhone_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone",
                column: "RestaruantID");

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantPhone_Restaruant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone",
                column: "RestaruantID",
                principalSchema: "Securities",
                principalTable: "Restaruant",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantPhone_Restaruant_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantPhone_RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone");

            migrationBuilder.DropColumn(
                name: "RestaruantID",
                schema: "Securities",
                table: "RestaurantPhone");
        }
    }
}
