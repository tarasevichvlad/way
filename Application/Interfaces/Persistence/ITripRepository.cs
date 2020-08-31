using System;
using Domain.Trips;

namespace Application.Interfaces.Persistence
{
    public interface ITripRepository : IRepository<Trip>
    {
        Trip GetTripWithPassengers(Guid tripId);
    }
}