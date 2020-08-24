using System;
using Domain.Shared;

namespace Domain.Cars
{
    public class Car : IEntity
    {
        public Guid Id { get; set; }
        public string Model { get; private set; }

        public Car(Guid id, string model)
        {
            Id = id;
            Model = model;
        }
    }
}