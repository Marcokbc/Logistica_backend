using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.Infraestructure.Migrations
{
    public partial class StatusGPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: "Pedido Efetuado");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: "Transito");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: "Transito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                value: 2);

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: 2);
        }
    }
}
