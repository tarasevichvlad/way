using System;
using System.Collections.Generic;
using Domain.Trips;

namespace Application.Trips.Queries.GetFinishedTripsQuery
{
    public interface IGetFinishedTripsQuery
    {
        IEnumerable<Trip> Execute(Guid userId);
    }
}