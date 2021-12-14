using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class AddingWaitingTimeForKitchen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WaitingTimeForKitchen",
                schema: "Order",
                table: "Order",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WaitingTimeForKitchen",
                schema: "Order",
                table: "Order");
        }
    }
}
