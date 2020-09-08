using System;
using Domain.Shared;
using Domain.Trips;
using Domain.Users;

namespace Domain.Passengers
{
    public class PassengerInfo
    {
        public Guid TripId { get; set; }
        public Guid PassengerId { get; set; }
        public User Passenger { get; set; }

        public PassengerInfo() { }

        public PassengerInfo(Trip trip, User passenger)
        {
            TripId = trip.Id;
            Passenger = passenger;
        }
    }
}