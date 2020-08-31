using System;

namespace Application.Trips.Commands.DeleteTripCommand
{
    public interface IDeleteTripCommand
    {
        void Execute(Guid tripId);
    }
}