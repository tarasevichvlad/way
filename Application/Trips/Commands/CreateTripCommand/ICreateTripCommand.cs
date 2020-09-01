using System;
using Application.Trips.Commands.Shared;

namespace Application.Trips.Commands.CreateTripCommand
{
    public interface ICreateTripCommand
    {
        void Execute(CreateAndUpdateTripModel model, Guid userId);
    }
}