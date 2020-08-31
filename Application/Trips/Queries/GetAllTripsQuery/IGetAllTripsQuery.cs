using System.Collections.Generic;
using Domain.Trips;

namespace Application.Trips.Queries.GetAllTripsQuery
{
    public interface IGetAllTripsQuery
    {
        IEnumerable<Trip> Execute();
    }
}