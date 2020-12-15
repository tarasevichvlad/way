using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.Trips.Commands.Shared;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;

namespace Application.Trips.Queries.SearchTripsQuery
{
    public class SearchTripsQuery : ISearchTripsQuery
    {
        private readonly ITripRepository _tripRepository;

        public SearchTripsQuery(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public List<Trip> Execute(SearchTripsModel searchTripsModel)
        {
            var trips = _tripRepository
                .GetAll()
                .Include(x => x.Driver)
                .Where(x =>
                    x.From.Equals(searchTripsModel.From) &&
                    x.To.Equals(searchTripsModel.To) &&
                    x.Seats - x.Passengers.Count >= searchTripsModel.Seats &&
                    x.StartingTime.Equals(searchTripsModel.DateTime) &&
                    x.OnlyTwoBehind.Equals(searchTripsModel.OnlyTwo))
                .ToList();

            return trips;
        }
    }
}