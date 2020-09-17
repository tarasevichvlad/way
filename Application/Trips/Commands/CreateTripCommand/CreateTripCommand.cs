using System;
using Application.Interfaces.Persistence;
using Application.Trips.Commands.Shared;
using Domain.Trips;
using FluentResults;

namespace Application.Trips.Commands.CreateTripCommand
{
    public class CreateTripCommand : ICreateTripCommand
    {
        private readonly ITripRepository _tripRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTripCommand(ITripRepository tripRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _tripRepository = tripRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(CreateAndUpdateTripModel model, Guid userId)
        {
            var user = _userRepository.Get(userId);

            var trip = new Trip(user, model.From, model.To, model.StartingTime, model.FinishTime, model.Price, model.Seats);
            
            trip.AddComment(model.Comment);

            _tripRepository.Add(trip);
            
            _unitOfWork.Save();

            return Result.Ok();
        }
    }
}