using System;
using FluentResults;

namespace Application.Users.Commands.UpdateUserCommand
{
    public interface IUpdateUserPhoneCommand
    {
        Result Execute(Guid userId, string phone);
    }
}