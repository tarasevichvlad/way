using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Domain.Passengers;
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
        public int Seats { get; private set; }
        public bool OnlyTwoBehind { get; set; }
        public DateTime StartingTime { get; private set; }
        public DateTime FinishTime { get; private set; }
        public List<PassengerInfo> Passengers { get; private set; } = new List<PassengerInfo>();
        [NotMapped]
        public bool UserApplied { get; set; }

        public Trip() {}

        public Trip(User driver, string from, string to, DateTime startingTime, DateTime finishTime, double price, int seats, bool onlyTwoBehind)
        {
            Driver = driver;
            From = from;
            To = to;
            StartingTime = startingTime;
            FinishTime = finishTime;
            Price = price;
            Seats = seats;
            OnlyTwoBehind = onlyTwoBehind;
        }

        public void AddComment(string comment)
        {
            Comment = comment;
        }

        public void AddPassenger(PassengerInfo passengerInfo)
        {
            Passengers.Add(passengerInfo);
        }

        public void RemovePassenger(User passenger)
        {
            var passengerInfo = Passengers.Find(x => x.PassengerId.Equals(passenger.Id));

            Passengers.Remove(passengerInfo);
        }

        public void CheckUserApplied(Guid userId)
        {
            if (Driver.Id.Equals(userId) || Passengers.Select(x => x.PassengerId.Equals(userId)).Any())
            {
                UserApplied = true;
            }
        }

        public void Update(string from, string to, DateTime startingTime, DateTime finishTime, double price, int seats, string comment, bool onlyTwoBehind)
        {
            if (!From.Equals(from))
            {
                From = from;
            }

            if (!To.Equals(to))
            {
                To = to;
            }

            if (!StartingTime.Equals(startingTime))
            {
                StartingTime = startingTime;
            }

            if (!FinishTime.Equals(finishTime))
            {
                FinishTime = finishTime;
            }

            if (!Price.Equals(price))
            {
                Price = price;
            }

            if (!Seats.Equals(seats))
            {
                Seats = seats;
            }
            
            if (!Comment.Equals(comment))
            {
                Comment = comment;
            }

            if (!OnlyTwoBehind.Equals(onlyTwoBehind))
            {
                OnlyTwoBehind = onlyTwoBehind;
            }
        }
    }
}