using System;
using Application.Interfaces.Persistence;

namespace Application.Trips.Commands.RemovePassengerCommand
{
    public class RemovePassengerCommand : IRemovePassengerCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ITripRepository _tripRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemovePassengerCommand(IUserRepository userRepository, ITripRepository tripRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _tripRepository = tripRepository;
            _unitOfWork = unitOfWork;
        }

        public void Execute(Guid tripId, Guid deletedUserId)
        {
            var trip = _tripRepository.GetTripWithPassengers(tripId);
            var deletedUser = _userRepository.Get(deletedUserId);

            trip.RemovePassenger(deletedUser);

            _unitOfWork.Save();
        }
    }
}