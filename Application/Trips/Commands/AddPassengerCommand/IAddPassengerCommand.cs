using System;
using FluentResults;

namespace Application.Trips.Commands.AddPassengerCommand
{
    public interface IAddPassengerCommand
    {
        Result Execute(Guid tripId, Guid userId);
    }
}