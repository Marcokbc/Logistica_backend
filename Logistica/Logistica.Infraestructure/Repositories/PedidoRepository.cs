using Logistica.Domain.Entities;
using Logistica.Domain.Interfaces;
using Logistica.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Infraestructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private ApplicationDbContext _pedidoContext;
        public PedidoRepository(ApplicationDbContext context)
        {
            _pedidoContext = context;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _pedidoContext.Add(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> GetByIdAsync(int? id)
        {
            //foreach(var pedido in _pedidoContext.Pedido)
            //{
            //    if (pedido.Id == id)
            //    {
            //        foreach(var rota in pedido.Rotas)
            //        {

            //                    }
            //    }
            //}

            return await _pedidoContext.Pedido.Include(c => c.Rotas.Where(r => r.IdPedido == id))
                 .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> GetByCodigoAsync(string? codigo)
        {
            return await _pedidoContext.Pedido.Where(n => n.CodigoRastreio.Contains(codigo)).ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> GetPedidosAsync()
        {
            return await _pedidoContext.Pedido.ToListAsync();
        }

        public async Task<Pedido> RemoveAsync(Pedido pedido)
        {
            _pedidoContext.Remove(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {
            _pedidoContext.Update(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }
    }
}
