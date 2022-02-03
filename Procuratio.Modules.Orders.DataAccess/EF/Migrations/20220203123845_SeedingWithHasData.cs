using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Order.DataAccess.EF.Migrations
{
    public partial class SeedingWithHasData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Order",
                table: "DeliveryState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Completado" },
                    { (short)2, "En curso" }
                });

            migrationBuilder.InsertData(
                schema: "Order",
                table: "OrderState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Pendiente" },
                    { (short)2, "En proceso" },
                    { (short)3, "Para entrega" },
                    { (short)4, "Entregado" },
                    { (short)5, "Esperando el pago" },
                    { (short)6, "Pagado" }
                });

            migrationBuilder.InsertData(
                schema: "Order",
                table: "ReserveState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)5, "No vino" },
                    { (short)4, "Completada" },
                    { (short)2, "Sin confirmar" },
                    { (short)1, "Pendiente" },
                    { (short)3, "En curso" }
                });

            migrationBuilder.InsertData(
                schema: "Order",
                table: "TableState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "Disponible" },
                    { (short)2, "Ocupada" }
                });

            migrationBuilder.InsertData(
                schema: "Order",
                table: "TakeAwayState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)1, "En curso" },
                    { (short)2, "Completado" },
                    { (short)3, "No vino" }
                });

            migrationBuilder.InsertData(
                schema: "Order",
                table: "WithoutReserveState",
                columns: new[] { "Id", "StateName" },
                values: new object[,]
                {
                    { (short)2, "En curso" },
                    { (short)1, "Completada" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Order",
                table: "DeliveryState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "DeliveryState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "OrderState",
                keyColumn: "Id",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "ReserveState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "ReserveState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "ReserveState",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "ReserveState",
                keyColumn: "Id",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "ReserveState",
                keyColumn: "Id",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "TableState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "TableState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "TakeAwayState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "TakeAwayState",
                keyColumn: "Id",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "TakeAwayState",
                keyColumn: "Id",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "WithoutReserveState",
                keyColumn: "Id",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                schema: "Order",
                table: "WithoutReserveState",
                keyColumn: "Id",
                keyValue: (short)2);
        }
    }
}
