using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Reviews;

namespace Application.Reviews.Query.GetAllReviewsQuery
{
    public class GetAllReviewsQuery : IGetAllReviewsQuery
    {
        private readonly IReviewRepository _reviewRepository;

        public GetAllReviewsQuery(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public IEnumerable<Review> Execute()
        {
            return _reviewRepository.GetAll().ToList();
        }
    }
}