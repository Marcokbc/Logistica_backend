using Logistica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Infraestructure.EntitiesConfiguration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Origem).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Destino).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder.HasData(
              new Pedido(1, "Material Escolar", "Brumado", "VCA", 1),
              new Pedido(2, "Eletrônicos", "Brumado", "VCA", 1),
              new Pedido(3, "Acessórios", "Brumado", "VCA", 1)
            );
        }
    }
}
