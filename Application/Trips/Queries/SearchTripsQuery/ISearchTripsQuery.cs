using System.Collections.Generic;
using Application.Trips.Commands.Shared;
using Domain.Trips;

namespace Application.Trips.Queries.SearchTripsQuery
{
    public interface ISearchTripsQuery
    {
        List<Trip> Execute(SearchTripsModel searchTripsModel);
    }
}