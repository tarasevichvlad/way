using System;
using Application.Interfaces.Persistence;
using Domain.Trips;
using FluentResults;

namespace Application.Trips.Queries.GetTripDetailQuery
{
    public class GetTripDetailQuery : IGetTripDetailQuery
    {
        private readonly ITripRepository _tripRepository;

        public GetTripDetailQuery(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public Result<Trip> Execute(Guid tripId)
        {
            var trip = _tripRepository.GetTripWithPassengers(tripId);

            if (trip != null)
            {
                return Result.Ok(trip);
            }
            
            return Result.Fail($"Trip with id: {tripId} not found");
        }
    }
}