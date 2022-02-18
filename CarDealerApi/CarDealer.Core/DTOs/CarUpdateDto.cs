namespace CarDealer.Core.DTOs
{
    public class CarUpdateDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
    }
}
