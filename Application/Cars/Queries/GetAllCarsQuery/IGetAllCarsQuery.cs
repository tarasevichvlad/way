using System.Collections.Generic;
using Domain.Cars;

namespace Application.Cars.Queries.GetAllCarsQuery
{
    public interface IGetAllCarsQuery
    {
        IEnumerable<Car> Execute();
    }
}