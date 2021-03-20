using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.Repositories
{
    internal class UniverseRepository : IUniverseRepository
    {
        private readonly UniverseDbContext _context;

        public UniverseRepository(UniverseDbContext context)
        {
            _context = context;
        }

        public async Task<Universe> GetActive()
        {
            return await _context.Set<Universe>().FirstOrDefaultAsync();
        }

        public async Task Add(Universe universe)
        {
            await _context.Set<Universe>().AddAsync(universe);
        }
    }
}