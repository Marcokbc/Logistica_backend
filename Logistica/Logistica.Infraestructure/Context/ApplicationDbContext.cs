using Logistica.Domain.Entities;
using Logistica.Infraestructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Infraestructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Rota> Rota { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext)
            .Assembly);

            builder.Entity<Pedido>()
            .Property(e => e.Status)
            .HasConversion(
                v => v.ToString(),
                v => (StatusPedido)Enum.Parse(typeof(StatusPedido), v));

            builder.Entity<Pedido>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Pedido>()
            .HasKey(p => p.Id);

            builder.Entity<Rota>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Rota>()
            .HasKey(p => p.Id);
        }
    }
}
