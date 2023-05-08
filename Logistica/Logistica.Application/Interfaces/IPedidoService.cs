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
        Task<PedidoDTO> GetByCodigo(string? codigo);
        Task<bool> Add(PedidoPostDTO pedidoDto);
        Task<bool> Update(PedidoDTO pedidoDto);
        Task<bool> Remove(int? id);
    }
}
