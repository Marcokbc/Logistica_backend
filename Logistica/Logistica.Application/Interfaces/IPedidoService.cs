using Logistica.Application.DTOs;
using Logistica.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PaginatedResult<PedidoDTO>> GetPedidos(int pageNumber, int pageSize);
        Task<PedidoDTO> GetById(int? id);
        Task<IEnumerable<PedidoDTO>> GetByCodigo(string? codigo);
        Task Add(PedidoDTO pedidoDto);
        Task Update(PedidoDTO pedidoDto);
        Task Remove(int? id);
    }
}
