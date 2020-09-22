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
        public string Phone { get; private set; }
        public double Rating { get; set; }
        public Car Car { get; private set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public User(string firstName, string lastName, string phone) : this(firstName, lastName)
        {
            Phone = phone;
        }

        public void AddId(Guid id)
        {
            Id = id;
        }

        public void AddOrUpdateCar(Car car)
        {
            Car ??= car;

            if (Car.Model != car.Model)
            {
                Car.Model = car.Model;
            }

            if (Car.RegistrationPlate != car.RegistrationPlate)
            {
                Car.RegistrationPlate = car.RegistrationPlate;
            }
        }

        public void UpdateRating(double rating)
        {
            Rating = rating;
        }

        public void AddPhone(string phone)
        {
            Phone = phone;
        }
    }
}