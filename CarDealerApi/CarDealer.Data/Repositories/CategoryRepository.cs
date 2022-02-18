using System.Linq;
using CarDealer.Core;
using CarDealer.Core.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Category> GetSingleCategoryByIdWithCarsAsync(int categoryId)
        {
            return await _context.Categories.Include(x => x.Cars).Where(x => x.Id == categoryId).SingleOrDefaultAsync();

        }
    }
}