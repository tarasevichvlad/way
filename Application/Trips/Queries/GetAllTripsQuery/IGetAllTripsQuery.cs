using System.Collections.Generic;
using Domain.Trips;
using FluentResults;

namespace Application.Trips.Queries.GetAllTripsQuery
{
    public interface IGetAllTripsQuery
    {
        IEnumerable<Trip> Execute();
    }
}