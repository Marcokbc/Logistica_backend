using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.Infraestructure.Migrations
{
    public partial class Status : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 1);
        }
    }
}
