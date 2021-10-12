using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class AddingIndexToOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Note",
                schema: "Order",
                table: "OrderDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BranchId_ItemId_OrderId",
                schema: "Order",
                table: "OrderDetail",
                columns: new[] { "BranchId", "ItemId", "OrderId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_BranchId_ItemId_OrderId",
                schema: "Order",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "Note",
                schema: "Order",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
