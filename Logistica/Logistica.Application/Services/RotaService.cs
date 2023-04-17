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
    public class RotaService
    {
        private IRotaRepository _rotaRepository;
        private readonly IMapper _mapper;
        public RotaService(IRotaRepository rotaRepository,
            IMapper mapper)
        {
            _rotaRepository = rotaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RotaDTO>> GetRotas()
        {
            var rotasEntity = await _rotaRepository.GetRotasAsync();
            return _mapper.Map<IEnumerable<RotaDTO>>(rotasEntity);
        }

        public async Task<RotaDTO> GetById(int? id)
        {
            var rotaEntity = await _rotaRepository.GetByIdAsync(id);
            return _mapper.Map<RotaDTO>(rotaEntity);
        }

        public async Task Add(RotaDTO rotaDto)
        {
            var rotaEntity = _mapper.Map<Rota>(rotaDto);
            await _rotaRepository.CreateAsync(rotaEntity);
        }

        public async Task Update(RotaDTO rotaDto)
        {
            var rotaEntity = _mapper.Map<Rota>(rotaDto);
            await _rotaRepository.UpdateAsync(rotaEntity);
        }

        public async Task Remove(int? id)
        {
            var rotaEntity = _rotaRepository.GetByIdAsync(id).Result;
            await _rotaRepository.RemoveAsync(rotaEntity);
        }
    }
}
