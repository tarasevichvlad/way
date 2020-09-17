using System;
using Domain.Shared;

namespace Domain.Cars
{
    public class Car : IEntity
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string RegistrationPlate { get; set; }

        public Car() {}

        public Car(string model)
        {
            Model = model;
        }

        public Car(Guid id, string model) : this(model)
        {
            Id = id;
        }

        public void AddRegistrationPlate(string registrationPlate)
        {
            RegistrationPlate = registrationPlate;
        }
    }
}