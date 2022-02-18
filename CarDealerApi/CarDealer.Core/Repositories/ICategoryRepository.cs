using System.Threading.Tasks;

namespace CarDealer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithCarsAsync(int categoryId);
    }
}