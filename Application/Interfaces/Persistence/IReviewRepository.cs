using System;
using System.Collections.Generic;
using Domain.Reviews;

namespace Application.Interfaces.Persistence
{
    public interface IReviewRepository : IRepository<Review>
    {
        IEnumerable<Review> GetMyReviews(Guid userId);
    }
}