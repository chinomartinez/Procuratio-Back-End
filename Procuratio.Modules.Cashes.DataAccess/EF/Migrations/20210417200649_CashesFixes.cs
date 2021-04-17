using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Migrations
{
    public partial class CashesFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementType_MovementType_MovementsTypeID",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.DropIndex(
                name: "IX_MovementType_MovementsTypeID",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.DropColumn(
                name: "MovementTypeID",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.DropColumn(
                name: "MovementsTypeID",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Cashes",
                table: "MovementType",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Cashes",
                table: "MovementType");

            migrationBuilder.AddColumn<int>(
                name: "MovementTypeID",
                schema: "Cashes",
                table: "MovementType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MovementsTypeID",
                schema: "Cashes",
                table: "MovementType",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantID",
                schema: "Cashes",
                table: "MovementType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovementType_MovementsTypeID",
                schema: "Cashes",
                table: "MovementType",
                column: "MovementsTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementType_MovementType_MovementsTypeID",
                schema: "Cashes",
                table: "MovementType",
                column: "MovementsTypeID",
                principalSchema: "Cashes",
                principalTable: "MovementType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
