using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Menues.DataAccess.EF.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDayOfWeekTimeRange_PromotionDayOfWeek_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.DropIndex(
                name: "IX_PromotionDayOfWeekTimeRange_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.DropColumn(
                name: "PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.DropColumn(
                name: "PromotionDayOfWeekPromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.RenameColumn(
                name: "DayOfweekID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                newName: "PromotionID");

            migrationBuilder.AddColumn<int>(
                name: "DayNumberID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDayOfWeekTimeRange_DayNumberID_PromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                columns: new[] { "DayNumberID", "PromotionID" });

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDayOfWeekTimeRange_PromotionDayOfWeek_DayNumberID_PromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                columns: new[] { "DayNumberID", "PromotionID" },
                principalSchema: "Menues",
                principalTable: "PromotionDayOfWeek",
                principalColumns: new[] { "PromotionID", "DayNumber" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PromotionDayOfWeekTimeRange_PromotionDayOfWeek_DayNumberID_PromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.DropIndex(
                name: "IX_PromotionDayOfWeekTimeRange_DayNumberID_PromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.DropColumn(
                name: "DayNumberID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange");

            migrationBuilder.RenameColumn(
                name: "PromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                newName: "DayOfweekID");

            migrationBuilder.AddColumn<int>(
                name: "PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PromotionDayOfWeekPromotionID",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PromotionDayOfWeekTimeRange_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                columns: new[] { "PromotionDayOfWeekPromotionID", "PromotionDayOfWeekDayNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_PromotionDayOfWeekTimeRange_PromotionDayOfWeek_PromotionDayOfWeekPromotionID_PromotionDayOfWeekDayNumber",
                schema: "Menues",
                table: "PromotionDayOfWeekTimeRange",
                columns: new[] { "PromotionDayOfWeekPromotionID", "PromotionDayOfWeekDayNumber" },
                principalSchema: "Menues",
                principalTable: "PromotionDayOfWeek",
                principalColumns: new[] { "PromotionID", "DayNumber" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
