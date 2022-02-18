using System.Collections.Generic;

namespace CarDealer.Core
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
