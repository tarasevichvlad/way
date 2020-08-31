using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Cars;

namespace Application.Cars.Queries.GetAllCarsQuery
{
    public class GetAllCarsQuery : IGetAllCarsQuery
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarsQuery(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public IEnumerable<Car> Execute()
        {
            return _carRepository.GetAll().ToList();
        }
    }
}