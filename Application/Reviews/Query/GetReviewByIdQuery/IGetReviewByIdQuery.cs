using System;
using System.Collections.Generic;
using Domain.Reviews;

namespace Application.Reviews.Query.GetReviewByIdQuery
{
    public interface IGetReviewByIdQuery
    {
        public IEnumerable<Review> Execute(Guid userId);
    }
}