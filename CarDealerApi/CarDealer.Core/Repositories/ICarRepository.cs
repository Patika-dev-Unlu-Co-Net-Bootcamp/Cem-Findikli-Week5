using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealer.Core.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<List<Car>> GetCarsWitCategory();
    }
}