using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Logistica.Infraestructure.Migrations
{
    public partial class codigoGUID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoRastreio",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 1,
                column: "CodigoRastreio",
                value: "c4a4f023-5159-4c2e-9bad-30897c4660ee");

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

            migrationBuilder.InsertData(
                table: "Pedido",
                columns: new[] { "Id", "CodigoRastreio", "Destino", "Nome", "Origem", "Status" },
                values: new object[,]
                {
                    { 4, "3f3a0117-ebf4-40d6-ad43-3b53a4a54749", "VCA", "Material Escolar", "Brumado", "Pedido Efetuado" },
                    { 5, "75f0f6a1-c879-4e20-8b64-be9274c55605", "VCA", "Eletrônicos", "Brumado", "Transito" },
                    { 6, "18bfa241-2dba-4af3-8fd1-d38db2c531ff", "VCA", "Acessórios", "Brumado", "Transito" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pedido",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "CodigoRastreio",
                table: "Pedido");
        }
    }
}
