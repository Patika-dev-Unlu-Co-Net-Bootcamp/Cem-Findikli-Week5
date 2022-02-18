namespace CarDealer.Core
{
    public class CarFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Km { get; set; }
        public int Year { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
