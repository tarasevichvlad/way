using System;
using Application.Interfaces.Persistence;
using Application.Trips.Commands.Shared;
using FluentResults;

namespace Application.Trips.Commands.UpdateTripCommand
{
    public class UpdateTripCommand : IUpdateTripCommand
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTripCommand(ITripRepository tripRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(CreateAndUpdateTripModel model, Guid tripId)
        {
            var trip = _tripRepository.Get(tripId);

            trip.Update(
                model.From,
                model.To,
                model.StartingTime,
                model.FinishTime,
                model.Price,
                model.Seats,
                model.Comment,
                model.OnlyTwo);

            _tripRepository.Update(trip);

            _unitOfWork.Save();
            
            return Result.Ok();
        }
    }
}