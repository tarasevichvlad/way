using System;
using Domain.Cars;
using Domain.Shared;

namespace Domain.Users
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Phone { get; private set; }
        public Car Car { get; private set; }

        public User(string firstName, string lastName, int phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
        }

        public void AddCar(Car car)
        {
            Car = car;
        }
    }
}