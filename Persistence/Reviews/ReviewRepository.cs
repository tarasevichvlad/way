using Application.Interfaces.Persistence;
using Domain.Reviews;
using Persistence.Shared;

namespace Persistence.Reviews
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}