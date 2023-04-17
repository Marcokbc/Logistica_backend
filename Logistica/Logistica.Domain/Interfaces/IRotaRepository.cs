using Logistica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistica.Domain.Interfaces
{
    public interface IRotaRepository
    {
        Task<IEnumerable<Rota>> GetRotasAsync();
        Task<Rota> GetByIdAsync(int? id);
        Task<Rota> CreateAsync(Rota product);
        Task<Rota> UpdateAsync(Rota product);
        Task<Rota> RemoveAsync(Rota product);
    }
}
