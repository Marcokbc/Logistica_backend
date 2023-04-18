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
    public class RotaConfiguration : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.NomeCidade).HasMaxLength(100).IsRequired();
            builder.Property(p => p.DataRota).IsRequired();
            builder.Property(p => p.NomeCidade).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.Pedido).WithMany(e => e.Rotas)
                .HasForeignKey(e => e.IdPedido);
        }
    }
}
