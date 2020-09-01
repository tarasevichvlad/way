using System.Collections.Generic;
using Domain.Reviews;

namespace Application.Reviews.Query.GetAllReviewsQuery
{
    public interface IGetAllReviewsQuery
    {
        IEnumerable<Review> Execute();
    }
}