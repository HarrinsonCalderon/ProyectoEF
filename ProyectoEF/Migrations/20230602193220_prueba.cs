using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEF.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("804d0754-53e7-498e-90d8-b7ccf34d7410"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 2, 14, 32, 19, 952, DateTimeKind.Local).AddTicks(63));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("804d0754-53e7-498e-90d8-b7ccf34d7411"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 2, 14, 32, 19, 952, DateTimeKind.Local).AddTicks(99));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("804d0754-53e7-498e-90d8-b7ccf34d7410"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 2, 9, 18, 21, 757, DateTimeKind.Local).AddTicks(9620));

            migrationBuilder.UpdateData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("804d0754-53e7-498e-90d8-b7ccf34d7411"),
                column: "FechaCreacion",
                value: new DateTime(2023, 6, 2, 9, 18, 21, 757, DateTimeKind.Local).AddTicks(9631));
        }
    }
}
