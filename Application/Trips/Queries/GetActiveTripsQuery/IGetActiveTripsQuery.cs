using System;
using System.Collections.Generic;
using Domain.Trips;

namespace Application.Trips.Queries.GetActiveTripsQuery
{
    public interface IGetActiveTripsQuery
    {
        IEnumerable<Trip> Execute(Guid userId);
    }
}