using System;

namespace Application.Trips.Commands.AddPassengerCommand
{
    public interface IAddPassengerCommand
    {
        void Execute(Guid tripId, Guid userId);
    }
}