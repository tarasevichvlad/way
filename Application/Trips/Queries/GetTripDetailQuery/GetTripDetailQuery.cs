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

        public Result<Trip> Execute(Guid tripId, Guid userId)
        {
            var trip = _tripRepository.GetTripWithPassengers(tripId);
            
            trip.CheckUserApplied(userId);

            if (trip != null)
            {
                return Result.Ok(trip);
            }
            
            return Result.Fail($"Trip with id: {tripId} not found");
        }
    }
}