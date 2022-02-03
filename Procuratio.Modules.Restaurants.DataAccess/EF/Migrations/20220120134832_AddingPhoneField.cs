using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Restaurant.DataAccess.EF.Migrations
{
    public partial class AddingPhoneField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "Restaurant",
                table: "Restaurant",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "Restaurant",
                table: "Branch",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "Restaurant",
                table: "Branch");

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                schema: "Restaurant",
                table: "Restaurant",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);
        }
    }
}
