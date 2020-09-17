using System;
using System.Collections.Generic;
using System.Linq;
using API.Extensions;
using Application.Reviews.Commands;
using Application.Reviews.Commands.CreateReviewCommand;
using Application.Reviews.Query;
using Application.Reviews.Query.GetAllReviewsQuery;
using Application.Reviews.Query.GetReviewByIdQuery;
using Domain.Reviews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Reviews
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly ICreateReviewCommand _createReviewCommand;
        private readonly IGetAllReviewsQuery _getAllReviewsQuery;
        private readonly IGetReviewByIdQuery _getReviewByIdQuery;

        public ReviewsController(
            ICreateReviewCommand createReviewCommand,
            IGetAllReviewsQuery getAllReviewsQuery,
            IGetReviewByIdQuery getReviewByIdQuery)
        {
            _createReviewCommand = createReviewCommand;
            _getAllReviewsQuery = getAllReviewsQuery;
            _getReviewByIdQuery = getReviewByIdQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAll()
        {
            return _getAllReviewsQuery.Execute().ToList();
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<Review>> GetReviewByUserId(Guid userId)
        {
            return _getReviewByIdQuery.Execute(userId).ToList();
        }

        [HttpGet("me")]
        public ActionResult<IEnumerable<Review>> GetMyReviews()
        {
            var userId = User.GetUserIdentifier();

            return _getReviewByIdQuery.Execute(userId).ToList();
        }
        
        [HttpPost]
        public IActionResult Create(CreateReviewModel createReviewModel)
        {
            _createReviewCommand.Execute(createReviewModel);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}