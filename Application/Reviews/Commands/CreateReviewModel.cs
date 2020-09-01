using System;

namespace Application.Reviews.Commands
{
    public class CreateReviewModel
    {
        public Guid From { get; set; }
        public Guid To { get; set; }
        public string Body { get; set; }
        public int Rating { get; set; }
    }
}