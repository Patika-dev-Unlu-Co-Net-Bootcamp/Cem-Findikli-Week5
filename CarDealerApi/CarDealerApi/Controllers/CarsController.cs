using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.DTOs;
using CarDealer.Core.Services;
namespace CarDealerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController 
    {
        private readonly IMapper _mapper;
        private readonly IService<Car> _service;

        public CarsController(IService<Car> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var cars = await _service.GetAllAsync();
            var carsDtos = _mapper.Map<List<CarDto>>(cars.ToList());
            return CreateActionResult(CustomResponseDto<List<CarDto>>.Success(200, carsDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _service.GetByIdAsync(id);
            var carsDto = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(200, carsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CarDto carDto)
        {
            var car = await _service.AddAsync(_mapper.Map<Car>(carDto));
            var carsDto = _mapper.Map<CarDto>(car);
            return CreateActionResult(CustomResponseDto<CarDto>.Success(201, carsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CarUpdateDto carDto)
        {
            await _service.AddAsync(_mapper.Map<Car>(carDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var car = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(car);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [NonAction]
        private IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode
                };
            }

            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }

    }
}
