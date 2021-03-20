using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUniverseRepository
    {
        Task<Universe> GetActive();
        Task Add(Universe universe);
    }
}