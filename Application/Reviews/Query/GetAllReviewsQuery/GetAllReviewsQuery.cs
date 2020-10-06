using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Reviews;
using Microsoft.EntityFrameworkCore;

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
            return _reviewRepository
                .GetAll()
                .Include(x => x.From)
                .Include(x => x.To)
                .ToList();
        }
    }
}