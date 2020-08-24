using System;
using System.Collections.Generic;
using Domain.Cars;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Cars
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasData(GetSeedData());
        }

        private static IEnumerable<Car> GetSeedData()
        {
            return new List<Car>
            {
                new Car(Guid.NewGuid(), "Model 1"),
                new Car(Guid.NewGuid(), "Model 2")
            };
        }
    }
}