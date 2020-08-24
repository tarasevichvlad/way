using Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Reviews
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.HasOne(x => x.From).WithOne().HasForeignKey<User>();
            //builder.HasOne(x => x.To).WithOne().HasForeignKey<User>();
        }
    }
}