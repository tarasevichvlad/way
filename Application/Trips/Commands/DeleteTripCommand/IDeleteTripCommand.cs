using System;
using FluentResults;

namespace Application.Trips.Commands.DeleteTripCommand
{
    public interface IDeleteTripCommand
    {
        Result Execute(Guid tripId);
    }
}