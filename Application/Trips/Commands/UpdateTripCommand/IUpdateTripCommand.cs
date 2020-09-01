using System;
using Application.Trips.Commands.Shared;

namespace Application.Trips.Commands.UpdateTripCommand
{
    public interface IUpdateTripCommand
    {
        void Execute(CreateAndUpdateTripModel createAndUpdateTripModel, Guid userId);
    }
}