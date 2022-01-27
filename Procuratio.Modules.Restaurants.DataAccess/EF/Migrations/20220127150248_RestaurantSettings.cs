using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class RestaurantSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setting",
                schema: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Constrained = table.Column<bool>(type: "bit", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MinValue = table.Column<int>(type: "int", nullable: true),
                    MaxValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AllowedSettingValue",
                schema: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    ItemValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllowedSettingValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllowedSettingValue_Setting_SettingId",
                        column: x => x.SettingId,
                        principalSchema: "Restaurant",
                        principalTable: "Setting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchSetting",
                schema: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    SettingId = table.Column<int>(type: "int", nullable: false),
                    UnconstrainedValue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchSetting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchSetting_Branch_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "Restaurant",
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchSetting_Setting_SettingId",
                        column: x => x.SettingId,
                        principalSchema: "Restaurant",
                        principalTable: "Setting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllowedSettingValue_SettingId",
                schema: "Restaurant",
                table: "AllowedSettingValue",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSetting_BranchId",
                schema: "Restaurant",
                table: "BranchSetting",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSetting_SettingId",
                schema: "Restaurant",
                table: "BranchSetting",
                column: "SettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllowedSettingValue",
                schema: "Restaurant");

            migrationBuilder.DropTable(
                name: "BranchSetting",
                schema: "Restaurant");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "Restaurant");
        }
    }
}
