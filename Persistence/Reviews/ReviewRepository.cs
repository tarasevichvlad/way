using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Reviews;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Reviews
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
        
        public IEnumerable<Review> GetMyReviews(Guid userId)
        {
            return DbSet
                .Include(x => x.From)
                .Include(x => x.To)
                .Where(x => x.To.Id.Equals(userId))
                .ToList();
        }
    }
}