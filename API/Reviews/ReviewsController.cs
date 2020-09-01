using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.Reviews.Commands;
using Application.Reviews.Query;
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

        public ReviewsController(
            ICreateReviewCommand createReviewCommand,
            IGetAllReviewsQuery getAllReviewsQuery)
        {
            _createReviewCommand = createReviewCommand;
            _getAllReviewsQuery = getAllReviewsQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAll()
        {
            return _getAllReviewsQuery.Execute().ToList();
        }

        [HttpPost]
        public IActionResult Create(CreateReviewModel createReviewModel)
        {
            _createReviewCommand.Execute(createReviewModel);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}