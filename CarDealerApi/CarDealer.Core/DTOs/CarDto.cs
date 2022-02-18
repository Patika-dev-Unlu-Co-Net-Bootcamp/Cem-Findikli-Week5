using CarDealer.Core.DTOs;

namespace CarDealer.Core.DTOs
{
    public class CarDto : BaseDto
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
