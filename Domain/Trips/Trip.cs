using System;
using Domain.Shared;
using Domain.Users;

namespace Domain.Trips
{
    public class Trip : IEntity
    {
        public Guid Id { get; set; }
        public User Driver { get; private set; }
        public double Price { get; private set; }
        public string Comment { get; private set; }
        public string From { get; private set; }
        public string To { get; private set; }
        public DateTime StartingTime { get; private set; }
        public DateTime FinishTime { get; private set; }

        public Trip() {}

        public Trip(User driver, string from, string to, DateTime startingTime, DateTime finishTime, double price)
        {
            Driver = driver;
            From = from;
            To = to;
            StartingTime = startingTime;
            FinishTime = finishTime;
            Price = price;
        }

        public void AddComment(string comment)
        {
            Comment = comment;
        }
    }
}