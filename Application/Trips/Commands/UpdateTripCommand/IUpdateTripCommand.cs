using System;
using Application.Trips.Commands.Shared;
using FluentResults;

namespace Application.Trips.Commands.UpdateTripCommand
{
    public interface IUpdateTripCommand
    {
        Result Execute(CreateAndUpdateTripModel createAndUpdateTripModel, Guid userId);
    }
}