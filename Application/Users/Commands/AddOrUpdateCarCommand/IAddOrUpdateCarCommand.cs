using System;
using Domain.Cars;
using FluentResults;

namespace Application.Users.Commands.AddOrUpdateCarCommand
{
    public interface IAddOrUpdateCarCommand
    {
        Result Execute(Guid userId, Car car);
    }
}