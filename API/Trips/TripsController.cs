using System;
using System.Collections.Generic;
using System.Linq;
using API.Extensions;
using Application.Trips.Commands.AddPassengerCommand;
using Application.Trips.Commands.CreateTripCommand;
using Application.Trips.Commands.DeleteTripCommand;
using Application.Trips.Commands.RemovePassengerCommand;
using Application.Trips.Commands.Shared;
using Application.Trips.Commands.UpdateTripCommand;
using Application.Trips.Queries.GetAllTripsQuery;
using Domain.Trips;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Trips
{
    [ApiController]
    [Route("[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly IGetAllTripsQuery _getAllTripsQuery;
        private readonly ICreateTripCommand _createTripCommand;
        private readonly IAddPassengerCommand _addPassengerCommand;
        private readonly IRemovePassengerCommand _removePassengerCommand;
        private readonly IDeleteTripCommand _deleteTripCommand;
        private readonly IUpdateTripCommand _updateTripCommand;

        public TripsController(
            IGetAllTripsQuery getAllTripsQuery,
            ICreateTripCommand createTripCommand,
            IAddPassengerCommand addPassengerCommand,
            IRemovePassengerCommand removePassengerCommand,
            IDeleteTripCommand deleteTripCommand,
            IUpdateTripCommand updateTripCommand)
        {
            _getAllTripsQuery = getAllTripsQuery;
            _createTripCommand = createTripCommand;
            _addPassengerCommand = addPassengerCommand;
            _removePassengerCommand = removePassengerCommand;
            _deleteTripCommand = deleteTripCommand;
            _updateTripCommand = updateTripCommand;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            return _getAllTripsQuery.Execute().ToList();
        }

        [HttpPost]
        public IActionResult Create(CreateAndUpdateTripModel createAndUpdateTripModel)
        {
            var userId = User.GetUserIdentifier();

            _createTripCommand.Execute(createAndUpdateTripModel, userId);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete("{tripId}")]
        public IActionResult Delete(Guid tripId)
        {
            _deleteTripCommand.Execute(tripId);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost("{tripId}/passenger")]
        public IActionResult AddPassengerToTrip(Guid tripId)
        {
            var userId = User.GetUserIdentifier();

            _addPassengerCommand.Execute(tripId, userId);

            return StatusCode(StatusCodes.Status200OK);
        }
        
        [HttpDelete("{tripId}/passenger")]
        public IActionResult RemovePassengerFromTrip(Guid tripId, Guid deletedUserId)
        {
            _removePassengerCommand.Execute(tripId, deletedUserId);

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{tripId}")]
        public IActionResult Update(Guid tripId, CreateAndUpdateTripModel createAndUpdateTripModel)
        {
            _updateTripCommand.Execute(createAndUpdateTripModel, tripId);
            
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}