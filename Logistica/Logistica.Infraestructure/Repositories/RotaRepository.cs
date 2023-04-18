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
    public class RotaRepository : IRotaRepository
    {
        private ApplicationDbContext _rotaContext;
        public RotaRepository(ApplicationDbContext context)
        {
            _rotaContext = context;
        }

        public async Task<Rota> CreateAsync(Rota product)
        {
            _rotaContext.Add(product);
            await _rotaContext.SaveChangesAsync();
            return product;
        }

        public async Task<Rota> GetByIdAsync(int? id)
        {
            return await _rotaContext.Rota.FindAsync(id);
        }

        public async Task<IEnumerable<Rota>> GetRotasAsync()
        {
            return await _rotaContext.Rota.ToListAsync();
        }

        public async Task<Rota> RemoveAsync(Rota rota)
        {
            _rotaContext.Remove(rota);
            await _rotaContext.SaveChangesAsync();
            return rota;
        }

        public async Task<Rota> UpdateAsync(Rota rota)
        {
            _rotaContext.Update(rota);
            await _rotaContext.SaveChangesAsync();
            return rota;
        }
    }
}
