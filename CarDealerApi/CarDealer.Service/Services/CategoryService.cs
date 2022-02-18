using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.DTOs;
using CarDealer.Core.Repositories;
using CarDealer.Core.Services;
using CarDealer.Core.UnitOfWorks;
using System.Threading.Tasks;

namespace CarDealer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository,IUnitOfWork unitOfWork,ICategoryRepository categoryRepository, IMapper mapper) : base(repository,unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithCarsDto>> GetSingleCategoryByIdWithCarsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithCarsAsync(categoryId);
            var categoryDto = _mapper.Map<CategoryWithCarsDto>(category);
            return CustomResponseDto<CategoryWithCarsDto>.Success(200, categoryDto);
        }
    }
}