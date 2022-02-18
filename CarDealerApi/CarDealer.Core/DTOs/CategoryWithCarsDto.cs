using System.Collections.Generic;

namespace CarDealer.Core.DTOs
{
    public class CategoryWithCarsDto : CategoryDto
    {
        public List<CarDto> Products { get; set; }
    }
}
