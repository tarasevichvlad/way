using System.Collections.Generic;
using System.Linq;
using Application.Cars.Queries.GetAllCarsQuery;
using Domain.Cars;
using Microsoft.AspNetCore.Mvc;

namespace API.Cars
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IGetAllCarsQuery _getAllCarsQuery;

        public CarsController(IGetAllCarsQuery getAllCarsQuery)
        {
            _getAllCarsQuery = getAllCarsQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            return _getAllCarsQuery.Execute().ToList();
        }
    }
}