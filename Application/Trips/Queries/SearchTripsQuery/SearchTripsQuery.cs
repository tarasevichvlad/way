using System;
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

        public List<Trip> Execute(SearchTripsModel searchTripsModel, Guid userId)
        {
            var trips = _tripRepository
                .GetAll()
                .Include(x => x.Driver)
                .Include(x => x.Passengers)
                .Where(x =>
                    x.From.Equals(searchTripsModel.From) &&
                    x.To.Equals(searchTripsModel.To) &&
                    !x.Driver.Id.Equals(userId) &&
                    !x.Passengers.Any(y => y.PassengerId.Equals(userId)) &&
                    x.Seats - x.Passengers.Count >= searchTripsModel.Seats &&
                    x.StartingTime >= searchTripsModel.DateTime &&
                    (searchTripsModel.OnlyTwo
                        ? x.OnlyTwoBehind.Equals(searchTripsModel.OnlyTwo)
                        : x.OnlyTwoBehind.Equals(true) || x.OnlyTwoBehind.Equals(false)))
                .ToList();

            foreach (var trip in trips)
            {
                trip.CheckUserApplied(userId);
            }

            return trips;
        }
    }
}