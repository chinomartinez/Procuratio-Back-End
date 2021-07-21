using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurants.DataAccess.EF.Migrations
{
    public partial class Restaurant_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Restaurant");

            migrationBuilder.CreateTable(
                name: "Restaurant",
                schema: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Withdrawn = table.Column<int>(type: "int", nullable: true),
                    DateWithdrawn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Branch_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalSchema: "Restaurant",
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_RestaurantID",
                schema: "Restaurant",
                table: "Branch",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Name",
                schema: "Restaurant",
                table: "Restaurant",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch",
                schema: "Restaurant");

            migrationBuilder.DropTable(
                name: "Restaurant",
                schema: "Restaurant");
        }
    }
}
