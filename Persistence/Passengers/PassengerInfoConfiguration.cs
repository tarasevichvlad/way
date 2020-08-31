using Domain.Passengers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Passengers
{
    public class PassengerInfoConfiguration : IEntityTypeConfiguration<PassengerInfo>
    {
        public void Configure(EntityTypeBuilder<PassengerInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}