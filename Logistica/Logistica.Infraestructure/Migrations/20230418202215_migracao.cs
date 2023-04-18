using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.Infraestructure.Migrations
{
    public partial class migracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rota_Pedido_PedidoId",
                table: "Rota");

            migrationBuilder.DropIndex(
                name: "IX_Rota_PedidoId",
                table: "Rota");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Rota");

            migrationBuilder.AlterColumn<string>(
                name: "Origem",
                table: "Pedido",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Destino",
                table: "Pedido",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Destino", "Nome", "Origem", "Status" },
                values: new object[] { 1, "VCA", "Material Escolar", "Brumado", 1 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Destino", "Nome", "Origem", "Status" },
                values: new object[] { 2, "VCA", "Eletrônicos", "Brumado", 1 });

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "Destino", "Nome", "Origem", "Status" },
                values: new object[] { 3, "VCA", "Acessórios", "Brumado", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Rota_IdPedido",
                table: "Rota",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Rota_Pedido_IdPedido",
                table: "Rota",
                column: "IdPedido",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rota_Pedido_IdPedido",
                table: "Rota");

            migrationBuilder.DropIndex(
                name: "IX_Rota_IdPedido",
                table: "Rota");

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Rota",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Origem",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Destino",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Rota_PedidoId",
                table: "Rota",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rota_Pedido_PedidoId",
                table: "Rota",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
