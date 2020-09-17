using System;
using Application.Trips.Commands.Shared;
using FluentResults;

namespace Application.Trips.Commands.CreateTripCommand
{
    public interface ICreateTripCommand
    {
        Result Execute(CreateAndUpdateTripModel model, Guid userId);
    }
}