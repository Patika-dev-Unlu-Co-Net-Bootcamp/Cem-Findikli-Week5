using System.Reflection;
using CarDealer.Core;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)//Veri tabanı yolunu startup üzerinden verebilmek için DbContext alan contractor oluşturuldu.
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<CarFeature>().HasData(new CarFeature()
                {
                    Id = 1,
                    Color = "Kırmızı",
                    Km = 100000,
                    Year = 2009,
                    CarId = 1
                },
                new CarFeature()
                {
                    Id = 2,
                    Color = "Siyah",
                    Km = 320000,
                    Year = 2016,
                    CarId = 2
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}