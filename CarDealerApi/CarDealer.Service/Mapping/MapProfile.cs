using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.DTOs;


namespace CarDealer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CarFeature, CarFeatureDto>().ReverseMap();
            CreateMap<CarUpdateDto, Car>();
            CreateMap<Car, CarWithCategoryDto>();
            CreateMap<Category, CategoryWithCarsDto>();
        }
    }
}
