using Logistica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDTO>> GetPedidos();
        Task<PedidoDTO> GetById(int? id);
        Task Add(PedidoDTO pedidoDto);
        Task Update(PedidoDTO pedidoDto);
        Task Remove(int? id);
    }
}
