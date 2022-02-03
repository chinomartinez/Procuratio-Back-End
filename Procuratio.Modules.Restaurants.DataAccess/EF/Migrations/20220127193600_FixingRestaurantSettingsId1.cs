using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class FixingRestaurantSettingsId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllowedSettingValue_Setting_SettingId",
                schema: "Restaurant",
                table: "AllowedSettingValue");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchSetting_Setting_SettingId",
                schema: "Restaurant",
                table: "BranchSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Setting",
                schema: "Restaurant",
                table: "Setting");

            migrationBuilder.DropIndex(
                name: "IX_BranchSetting_SettingId",
                schema: "Restaurant",
                table: "BranchSetting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllowedSettingValue",
                schema: "Restaurant",
                table: "AllowedSettingValue");

            migrationBuilder.DropIndex(
                name: "IX_AllowedSettingValue_SettingId",
                schema: "Restaurant",
                table: "AllowedSettingValue");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Restaurant",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Restaurant",
                table: "AllowedSettingValue");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Restaurant",
                table: "Setting",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Restaurant",
                table: "AllowedSettingValue",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Setting",
                schema: "Restaurant",
                table: "Setting",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllowedSettingValue",
                schema: "Restaurant",
                table: "AllowedSettingValue",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BranchSetting_SettingId",
                schema: "Restaurant",
                table: "BranchSetting",
                column: "SettingId");

            migrationBuilder.CreateIndex(
                name: "IX_AllowedSettingValue_SettingId",
                schema: "Restaurant",
                table: "AllowedSettingValue",
                column: "SettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllowedSettingValue_Setting_SettingId",
                schema: "Restaurant",
                table: "AllowedSettingValue",
                column: "SettingId",
                principalSchema: "Restaurant",
                principalTable: "Setting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchSetting_Setting_SettingId",
                schema: "Restaurant",
                table: "BranchSetting",
                column: "SettingId",
                principalSchema: "Restaurant",
                principalTable: "Setting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
