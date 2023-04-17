using Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetPedidosAsync();
        Task<Pedido> GetByIdAsync(int? id);
        Task<Pedido> CreateAsync(Pedido product);
        Task<Pedido> UpdateAsync(Pedido product);
        Task<Pedido> RemoveAsync(Pedido product);
    }
}
