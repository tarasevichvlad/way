using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Reviews;

namespace Application.Reviews.Query.GetReviewByIdQuery
{
    public class GetReviewByIdQuery : IGetReviewByIdQuery
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByIdQuery(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> Execute(Guid userId)
        {
            return _reviewRepository.GetMyReviews(userId);
        }
    }
}