using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Trips;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Trips
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public Trip GetTripWithPassengers(Guid tripId)
        {
            return DbSet
                .Include(x => x.Passengers)
                .SingleOrDefault(x => x.Id.Equals(tripId));
        }
    }
}