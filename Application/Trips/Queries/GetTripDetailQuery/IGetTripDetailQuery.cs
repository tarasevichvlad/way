using System;
using Domain.Trips;
using FluentResults;

namespace Application.Trips.Queries.GetTripDetailQuery
{
    public interface IGetTripDetailQuery
    {
        public Result<Trip> Execute(Guid tripId, Guid userId);
    }
}