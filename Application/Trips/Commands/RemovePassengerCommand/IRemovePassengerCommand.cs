using System;
using FluentResults;

namespace Application.Trips.Commands.RemovePassengerCommand
{
    public interface IRemovePassengerCommand
    {
        Result Execute(Guid tripId, Guid deletedUserId);
    }
}