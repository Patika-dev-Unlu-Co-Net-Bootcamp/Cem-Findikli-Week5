using CarDealer.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealer.Core.Services
{
    public interface ICarService: IService<Car>
    {
        Task<CustomResponseDto<List<CarWithCategoryDto>>> GetProductsWithCategory();
    }
}