using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class BranchSettingIndexInBranchSettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BranchSetting_BranchId",
                schema: "Restaurant",
                table: "BranchSetting");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSetting_BranchId_SettingId",
                schema: "Restaurant",
                table: "BranchSetting",
                columns: new[] { "BranchId", "SettingId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BranchSetting_BranchId_SettingId",
                schema: "Restaurant",
                table: "BranchSetting");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSetting_BranchId",
                schema: "Restaurant",
                table: "BranchSetting",
                column: "BranchId");
        }
    }
}
