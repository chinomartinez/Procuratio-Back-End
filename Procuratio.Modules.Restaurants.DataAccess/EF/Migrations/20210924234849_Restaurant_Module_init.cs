using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
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
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                schema: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Withdrawn = table.Column<int>(type: "int", nullable: true),
                    DateWithdrawn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Restaurant_RestaurantId",
                        column: x => x.RestaurantId,
                        principalSchema: "Restaurant",
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_RestaurantId",
                schema: "Restaurant",
                table: "Branch",
                column: "RestaurantId");

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
