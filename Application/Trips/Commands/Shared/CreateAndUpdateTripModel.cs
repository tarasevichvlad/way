using System;

namespace Application.Trips.Commands.Shared
{
    public class CreateAndUpdateTripModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Price { get; set; }
        public string Comment { get; set; }
        public int Seats { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}