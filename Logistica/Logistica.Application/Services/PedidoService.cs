using AutoMapper;
using Logistica.Application.DTOs;
using Logistica.Domain.Entities;
using Logistica.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Services
{
    public class PedidoService
    {
        private IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        public PedidoService(IPedidoRepository pedidoRepository,
            IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PedidoDTO>> GetPedidos()
        {
            var pedidosEntity = await _pedidoRepository.GetPedidosAsync();
            return _mapper.Map<IEnumerable<PedidoDTO>>(pedidosEntity);
        }

        public async Task<PedidoDTO> GetById(int? id)
        {
            var pedidoEntity = await _pedidoRepository.GetByIdAsync(id);
            return _mapper.Map<PedidoDTO>(pedidoEntity);
        }

        public async Task Add(PedidoDTO pedidoDto)
        {
            var pedidoEntity = _mapper.Map<Pedido>(pedidoDto);
            await _pedidoRepository.CreateAsync(pedidoEntity);
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
    }
}
