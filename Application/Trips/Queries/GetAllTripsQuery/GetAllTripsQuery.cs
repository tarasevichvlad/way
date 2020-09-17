using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;

namespace Application.Trips.Queries.GetAllTripsQuery
{
    public class GetAllTripsQuery : IGetAllTripsQuery
    {
        private readonly ITripRepository _tripRepository;

        public GetAllTripsQuery(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public IEnumerable<Trip>  Execute()
        {
            return _tripRepository
                .GetAll()
                .Include(x => x.Passengers)
                .Include(x => x.Driver).ThenInclude(x => x.Car)
                .ToList();
        }
    }
}