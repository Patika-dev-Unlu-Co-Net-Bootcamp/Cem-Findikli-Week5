namespace CarDealer.Core
{
    public class Car: BaseEntity
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public CarFeature CarFeature { get; set; }
    }
}
