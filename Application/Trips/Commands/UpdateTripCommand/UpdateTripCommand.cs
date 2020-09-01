using System;
using Application.Interfaces.Persistence;
using Application.Trips.Commands.Shared;

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

        public void Execute(CreateAndUpdateTripModel model, Guid tripId)
        {
            var trip = _tripRepository.Get(tripId);

            trip.Update(model.From, model.To, model.StartingTime, model.FinishTime, model.Price, model.Seats, model.Comment);

            _tripRepository.Update(trip);

            _unitOfWork.Save();
        }
    }
}