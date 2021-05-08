using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Customers.DataAccess.EF.Migrations
{
    public partial class Customers_Module_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerXOrderState",
                schema: "Customers",
                columns: table => new
                {
                    ID = table.Column<short>(type: "smallint", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerXOrderState", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerXOrder",
                schema: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerXOrderStateID = table.Column<short>(type: "smallint", nullable: false),
                    RestaurantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerXOrder", x => new { x.CustomerID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_CustomerXOrder_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalSchema: "Customers",
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerXOrder_CustomerXOrderState_CustomerXOrderStateID",
                        column: x => x.CustomerXOrderStateID,
                        principalSchema: "Customers",
                        principalTable: "CustomerXOrderState",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerXOrder_CustomerXOrderStateID",
                schema: "Customers",
                table: "CustomerXOrder",
                column: "CustomerXOrderStateID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerXOrder",
                schema: "Customers");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "Customers");

            migrationBuilder.DropTable(
                name: "CustomerXOrderState",
                schema: "Customers");
        }
    }
}
