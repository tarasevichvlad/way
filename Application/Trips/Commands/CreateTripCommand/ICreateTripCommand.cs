using System;

namespace Application.Trips.Commands.CreateTripCommand
{
    public interface ICreateTripCommand
    {
        void Execute(CreateTripModel model, Guid userId);
    }
}