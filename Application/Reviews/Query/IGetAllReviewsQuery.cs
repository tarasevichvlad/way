using System.Collections.Generic;
using Domain.Reviews;

namespace Application.Reviews.Query
{
    public interface IGetAllReviewsQuery
    {
        IEnumerable<Review> Execute();
    }
}