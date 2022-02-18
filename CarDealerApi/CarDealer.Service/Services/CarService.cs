using CarDealer.Core;
using CarDealer.Core.DTOs;
using CarDealer.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core.Repositories;
using CarDealer.Core.UnitOfWorks;

namespace CarDealer.Service.Services
{
    public class CarService : Service<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        public CarService(IGenericRepository<Car> repository, IUnitOfWork unitOfWork, IMapper mapper, ICarRepository carRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _carRepository = carRepository;
        }
        public async Task<CustomResponseDto<List<CarWithCategoryDto>>> GetProductsWithCategory()
        {
            var cars = await _carRepository.GetCarsWitCategory();
            var carsDto = _mapper.Map<List<CarWithCategoryDto>>(cars);
            return CustomResponseDto<List<CarWithCategoryDto>>.Success(200, carsDto);
        }
    }
}