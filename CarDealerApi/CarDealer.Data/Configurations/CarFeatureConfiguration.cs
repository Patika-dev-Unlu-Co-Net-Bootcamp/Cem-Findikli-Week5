using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealer.Repository.Configurations
{
    internal class CarFeatureConfiguration : IEntityTypeConfiguration<CarFeature>
    {
        public void Configure(EntityTypeBuilder<CarFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Car).WithOne(x => x.CarFeature).HasForeignKey<CarFeature>(x => x.CarId);

        }
    }
}
