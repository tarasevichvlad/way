using System;
using Application.Interfaces.Persistence;
using FluentResults;

namespace Application.Users.Commands.UpdateUserCommand
{
    public class UpdateUserPhoneCommand : IUpdateUserPhoneCommand
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserPhoneCommand(
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public Result Execute(Guid userId, string phone)
        {
            var user = _userRepository.Get(userId);

            if (user == null)
            {
                return Result.Fail("User not found");
            }

            user.AddPhone(phone);

            _userRepository.Update(user);

            _unitOfWork.Save();

            return Result.Ok();
        }
    }
}