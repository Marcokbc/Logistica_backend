using AutoMapper;
using Logistica.Application.DTOs;
using Logistica.Application.Interfaces;
using Logistica.Domain.Entities;
using Logistica.Domain.Interfaces;
using Logistica.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoService(IPedidoRepository pedidoRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<PedidoDTO>> GetPedidos(int pageNumber, int pageSize)
        {
            var pedidosEntity = await _pedidoRepository.GetPedidosAsync();
            var totalItems = pedidosEntity.Count();
            var items = pedidosEntity.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var pedidos = new PaginatedResult<Pedido>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = items
            };

            return _mapper.Map<PaginatedResult<PedidoDTO>>(pedidos);
        }

        public async Task<PedidoDTO> GetById(int? id)
        {
            var pedidoEntity = await _pedidoRepository.GetByIdAsync(id);
            return _mapper.Map<PedidoDTO>(pedidoEntity);
        }

        public async Task<bool> Add(PedidoDTO pedidoDto)
        {
            Validator.ValidateObject(pedidoDto, new ValidationContext(pedidoDto), true);

            var pedidoEntity = _mapper.Map<Pedido>(pedidoDto);
            var pedido = await _pedidoRepository.CreateAsync(pedidoEntity);
            return true;
            
        }

        public async Task Update(PedidoDTO pedidoDto)
        {
            var pedidoEntity = _mapper.Map<Pedido>(pedidoDto);
            await _pedidoRepository.UpdateAsync(pedidoEntity);
        }

        public async Task Remove(int? id)
        {
            var pedidoEntity = _pedidoRepository.GetByIdAsync(id).Result;
            await _pedidoRepository.RemoveAsync(pedidoEntity);
        }

        public async Task<IEnumerable<PedidoDTO>> GetByCodigo(string? codigo)
        {
                var pedidoEntity = await _pedidoRepository.GetByCodigoAsync(codigo);
                return _mapper.Map<IEnumerable<PedidoDTO>>(pedidoEntity); 
        }
    }
}
