using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.Infraestructure.Migrations
{
    public partial class StatusPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodigoRastreio", "Status" },
                values: new object[] { "e317d6e6-8a7b-4fba-b29a-7faf7f3e999e", "PedidoEfetuado" });

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "CodigoRastreio",
                value: "aec597d8-2380-4057-abac-92bdbc23821e");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "CodigoRastreio",
                value: "9925a76c-ab66-4278-8fa9-f2580e0ad2e5");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CodigoRastreio", "Status" },
                values: new object[] { "145ed377-4cac-41e1-b704-93aacbe72471", "PedidoEfetuado" });

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 5,
                column: "CodigoRastreio",
                value: "93059628-0894-4380-9fd1-6485748dea82");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 6,
                column: "CodigoRastreio",
                value: "f3da150e-661a-4200-aa82-37776e9bcfa0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CodigoRastreio", "Status" },
                values: new object[] { "c4a4f023-5159-4c2e-9bad-30897c4660ee", "Pedido Efetuado" });

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 2,
                column: "CodigoRastreio",
                value: "f30fb0eb-2085-4fa2-b2fd-140e7d0cd5ff");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 3,
                column: "CodigoRastreio",
                value: "95c7be2e-7eac-4a0f-a1fb-3109bbefbfe9");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CodigoRastreio", "Status" },
                values: new object[] { "3f3a0117-ebf4-40d6-ad43-3b53a4a54749", "Pedido Efetuado" });

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 5,
                column: "CodigoRastreio",
                value: "75f0f6a1-c879-4e20-8b64-be9274c55605");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 6,
                column: "CodigoRastreio",
                value: "18bfa241-2dba-4af3-8fd1-d38db2c531ff");
        }
    }
}
