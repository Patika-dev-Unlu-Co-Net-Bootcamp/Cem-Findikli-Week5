using CarDealer.Core;
using CarDealer.Core.DTOs;
using CarDealer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core.Repositories;
using CarDealer.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CarDealer.Caching
{
    public class CarServiceWithCaching: ICarService
    {
        private const string CacheCarKey = "carsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly ICarRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CarServiceWithCaching(IUnitOfWork unitOfWork, ICarRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            if (!_memoryCache.TryGetValue(CacheCarKey, out _))
            {
                _memoryCache.Set(CacheCarKey, _repository.GetCarsWitCategory().Result);
            }
        }

        public async Task<Car> AddAsync(Car entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;
        }

        public async Task<IEnumerable<Car>> AddRangeAsync(IEnumerable<Car> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<Car, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetAllAsync()
        {

            var products = _memoryCache.Get<IEnumerable<Car>>(CacheCarKey);
            return Task.FromResult(products);
        }

        public Task<Car> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<Car>>(CacheCarKey).FirstOrDefault(x => x.Id == id);
            //if (product == null)
            //{
            //    throw new NotFoundExcepiton($"{typeof(Car).Name}({id}) not found");
            //}
            return Task.FromResult(product);
        }

        public Task<CustomResponseDto<List<CarWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = _memoryCache.Get<IEnumerable<Car>>(CacheCarKey);

            var productsWithCategoryDto = _mapper.Map<List<CarWithCategoryDto>>(products);

            return Task.FromResult(CustomResponseDto<List<CarWithCategoryDto>>.Success(200, productsWithCategoryDto));
        }

        public async Task RemoveAsync(Car entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Car> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(Car entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<Car> Where(Expression<Func<Car, bool>> expression)
        {
            return _memoryCache.Get<List<Car>>(CacheCarKey).Where(expression.Compile()).AsQueryable();
        }


        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(CacheCarKey, await _repository.GetAll().ToListAsync());

        }
    }
}