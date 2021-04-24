﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Procuratio.Modules.Customers.DataAccess.EF.Migrations
{
    public partial class updatingStatesTablesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "Customers",
                table: "CustomerXOrderState",
                newName: "StateName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StateName",
                schema: "Customers",
                table: "CustomerXOrderState",
                newName: "Name");
        }
    }
}