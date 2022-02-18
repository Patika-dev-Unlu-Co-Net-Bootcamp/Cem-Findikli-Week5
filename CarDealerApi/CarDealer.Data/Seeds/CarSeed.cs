using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.Repository.Seeds
{
    internal class CarSeed : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new Car
                {
                    Id = 1,
                    CategoryId = 1,
                    Model = "Volvo",
                    Price = 800000,
                    Brand = "Xc90",
                    CreatedDate = DateTime.Now
                },
                new Car
                {
                    Id = 2,
                    CategoryId = 1,
                    Model = "A180",
                    Price = 550000,
                    Brand = "Mercedes",
                    CreatedDate = DateTime.Now
                },
                new Car
                {
                    Id = 3,
                    CategoryId = 1,
                    Model = "Bmw",
                    Price = 600000,
                    Brand = "3.20i",
                    CreatedDate = DateTime.Now
                },
                new Car
                {
                    Id = 4,
                    CategoryId = 2,
                    Model = "Ford",
                    Price = 600000,
                    Brand = "Focus",
                    CreatedDate = DateTime.Now
                },
                new Car
                {
                    Id = 5,
                    CategoryId = 2,
                    Model = "Ford",
                    Price = 660000,
                    Brand = "Kuga",
                    CreatedDate = DateTime.Now
                });
        }
    }
}
