using Application.Interfaces.Persistence;
using Domain.Cars;
using Persistence.Shared;

namespace Persistence.Cars
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        public CarRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}