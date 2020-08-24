using System;
using Domain.Shared;
using Domain.Users;

namespace Domain.Reviews
{
    public class Review : IEntity
    {
        public Guid Id { get; set; }
        public User From { get; private set; }
        public User To { get; private set; }
        public string Body { get; private set; }
        public double Rating { get; private set; }

        public Review() {}

        public Review(User @from, User to, string body, double rating)
        {
            From = @from;
            To = to;
            Body = body;
            Rating = rating;
        }
    }
}