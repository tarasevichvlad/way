using Application.Interfaces.Persistence;
using Domain.Trips;
using Persistence.Shared;

namespace Persistence.Trips
{
    public class TripRepository : Repository<Trip>, ITripRepository
    {
        public TripRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}