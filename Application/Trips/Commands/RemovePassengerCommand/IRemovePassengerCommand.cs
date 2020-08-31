using System;

namespace Application.Trips.Commands.RemovePassengerCommand
{
    public interface IRemovePassengerCommand
    {
        void Execute(Guid tripId, Guid deletedUserId);
    }
}