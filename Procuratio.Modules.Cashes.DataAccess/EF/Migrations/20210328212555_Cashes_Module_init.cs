using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Cashes.DataAccess.EF.Migrations
{
    public partial class Cashes_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cashes");

            migrationBuilder.CreateTable(
                name: "CashState",
                schema: "Cashes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovementType",
                schema: "Cashes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementTypeID = table.Column<int>(type: "int", nullable: false),
                    MovementsTypeID = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MovementType_MovementType_MovementsTypeID",
                        column: x => x.MovementsTypeID,
                        principalSchema: "Cashes",
                        principalTable: "MovementType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MountType",
                schema: "Cashes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MovementTypeID = table.Column<int>(type: "int", nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MountType_MovementType_MovementTypeID",
                        column: x => x.MovementTypeID,
                        principalSchema: "Cashes",
                        principalTable: "MovementType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cash",
                schema: "Cashes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    MountTypeID = table.Column<int>(type: "int", nullable: false),
                    CashStateID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cash", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cash_CashState_CashStateID",
                        column: x => x.CashStateID,
                        principalSchema: "Cashes",
                        principalTable: "CashState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cash_MountType_MountTypeID",
                        column: x => x.MountTypeID,
                        principalSchema: "Cashes",
                        principalTable: "MountType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cash_CashStateID",
                schema: "Cashes",
                table: "Cash",
                column: "CashStateID");

            migrationBuilder.CreateIndex(
                name: "IX_Cash_MountTypeID",
                schema: "Cashes",
                table: "Cash",
                column: "MountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MountType_MovementTypeID",
                schema: "Cashes",
                table: "MountType",
                column: "MovementTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_MovementType_MovementsTypeID",
                schema: "Cashes",
                table: "MovementType",
                column: "MovementsTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cash",
                schema: "Cashes");

            migrationBuilder.DropTable(
                name: "CashState",
                schema: "Cashes");

            migrationBuilder.DropTable(
                name: "MountType",
                schema: "Cashes");

            migrationBuilder.DropTable(
                name: "MovementType",
                schema: "Cashes");
        }
    }
}
