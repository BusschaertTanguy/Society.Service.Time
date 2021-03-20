using System.Threading.Tasks;
using Application.Transactions;
using Infrastructure.EntityFramework.Contexts;

namespace Infrastructure.EntityFramework.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniverseDbContext _context;

        public UnitOfWork(UniverseDbContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}