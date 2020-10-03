using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;

namespace Application.Trips.Queries.GetActiveTripsQuery
{
    public class GetActiveTripsQuery : IGetActiveTripsQuery
    {
        private readonly ITripRepository _tripRepository;

        public GetActiveTripsQuery(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public IEnumerable<Trip> Execute(Guid userId)
        {
            var currentDate = DateTime.Now;

            var items = _tripRepository
                .GetAll()
                .Where(
                    x => (x.Driver.Id.Equals(userId) ||
                          x.Passengers.Any(y => y.PassengerId.Equals(userId))) &&
                         x.FinishTime > currentDate)
                .Include(x => x.Passengers)
                .Include(x => x.Driver).ThenInclude(x => x.Car)
                .ToList();

            return items;
        }
    }
}