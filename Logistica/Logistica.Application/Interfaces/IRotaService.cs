using Logistica.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Application.Interfaces
{
    public interface IRotaService
    {
        Task<IEnumerable<RotaDTO>> GetProdutos();
        Task<RotaDTO> GetById(int? id);
        Task Add(RotaDTO rotaDto);
        Task Update(RotaDTO rotaDto);
        Task Remove(int? id);
    }
}
