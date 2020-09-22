using System;

namespace Application.Reviews.Commands.CreateReviewCommand
{
    public class CreateReviewModel
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Body { get; set; }
        public double Rating { get; set; }
    }
}