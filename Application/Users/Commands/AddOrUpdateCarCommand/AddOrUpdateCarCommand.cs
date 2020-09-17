using System;
using Application.Interfaces.Persistence;
using Domain.Cars;
using FluentResults;

namespace Application.Users.Commands.AddOrUpdateCarCommand
{
    public class AddOrUpdateCarCommand : IAddOrUpdateCarCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly ICarRepository _carRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddOrUpdateCarCommand(
            IUserRepository userRepository,
            ICarRepository carRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _carRepository = carRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(Guid userId, Car car)
        {
            var user = _userRepository.GetUserWithCarById(userId);
            var existCar = _carRepository.Get(car.Id);

            if (existCar == null)
            {
                _carRepository.Add(car);
            }

            user.AddOrUpdateCar(car);

            _unitOfWork.Save();

            return Result.Ok();
        }
    }
}