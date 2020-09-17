using System;
using Application.Interfaces.Persistence;
using Domain.Passengers;
using FluentResults;

namespace Application.Trips.Commands.AddPassengerCommand
{
    public class AddPassengerCommand : IAddPassengerCommand
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddPassengerCommand(ITripRepository tripRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(Guid tripId, Guid userId)
        {
            var trip = _tripRepository.Get(tripId);
            var user = _userRepository.Get(userId);

            var passengerInfo = new PassengerInfo(trip, user);

            trip.AddPassenger(passengerInfo);

            _unitOfWork.Save();
            
            return Result.Ok();
        }
    }
}