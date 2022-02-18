using System;

namespace CarDealer.Core
{
    //Base entityden nesne alınmaması için abstract yapıldı.
    public abstract class BaseEntity
    {
        //Tüm tablolarda olması gereken belirli sütunlar
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
