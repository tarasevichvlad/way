using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICarRepository _carRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _carRepository = carRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            var user = HttpContext;
            _logger.LogInformation("Get cars");

            var cars = _carRepository.GetAll().ToList();
            
            foreach (var car in cars)
            {
                _logger.LogInformation($"Car Id {car.Id} Model {car.Model}");
            }
            

            return cars;
        }
    }
}