using System;

namespace Application.Trips.Commands.Shared
{
    public class SearchTripsModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DateTime { get; set; }
        public int Seats { get; set; }
        public bool OnlyTwo { get; set; }
    }
}