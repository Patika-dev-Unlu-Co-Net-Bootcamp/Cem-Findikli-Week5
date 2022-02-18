using System.Threading.Tasks;
using CarDealer.Core.DTOs;

namespace CarDealer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithCarsDto>> GetSingleCategoryByIdWithCarsAsync(int categoryId);

    }
}