using System;
using Application.Interfaces.Persistence;
using FluentResults;

namespace Application.Trips.Commands.DeleteTripCommand
{
    public class DeleteTripCommand : IDeleteTripCommand
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTripCommand(ITripRepository tripRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(Guid tripId)
        {
            var trip = _tripRepository.Get(tripId);

            _tripRepository.Remove(trip);

            _unitOfWork.Save();
            
            return Result.Ok();
        }
    }
}