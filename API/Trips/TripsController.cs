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
using Application.Trips.Queries.GetTripDetailQuery;
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
        private readonly IGetTripDetailQuery _getTripDetailQuery;

        public TripsController(
            IGetAllTripsQuery getAllTripsQuery,
            ICreateTripCommand createTripCommand,
            IAddPassengerCommand addPassengerCommand,
            IRemovePassengerCommand removePassengerCommand,
            IDeleteTripCommand deleteTripCommand,
            IUpdateTripCommand updateTripCommand,
            IGetTripDetailQuery getTripDetailQuery)
        {
            _getAllTripsQuery = getAllTripsQuery;
            _createTripCommand = createTripCommand;
            _addPassengerCommand = addPassengerCommand;
            _removePassengerCommand = removePassengerCommand;
            _deleteTripCommand = deleteTripCommand;
            _updateTripCommand = updateTripCommand;
            _getTripDetailQuery = getTripDetailQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Trip>> Get()
        {
            return _getAllTripsQuery.Execute().ToList();
        }

        [HttpGet("{tripId}")]
        public ActionResult<Trip> GetById(Guid tripId)
        {
            var result = _getTripDetailQuery.Execute(tripId);

            return result.IsSuccess ? (ActionResult<Trip>) result.Value : BadRequest(result.Errors);
        }

        [HttpPost]
        public ActionResult Create(CreateAndUpdateTripModel createAndUpdateTripModel)
        {
            var userId = User.GetUserIdentifier();

            var result = _createTripCommand.Execute(createAndUpdateTripModel, userId);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status201Created) : BadRequest(result.Errors);
        }

        [HttpDelete("{tripId}")]
        public IActionResult Delete(Guid tripId)
        {
            var result = _deleteTripCommand.Execute(tripId);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }

        [HttpPost("{tripId}/passenger")]
        public IActionResult AddPassengerToTrip(Guid tripId)
        {
            var userId = User.GetUserIdentifier();

            var result = _addPassengerCommand.Execute(tripId, userId);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }

        [HttpDelete("{tripId}/passenger")]
        public IActionResult RemovePassengerFromTrip(Guid tripId, Guid deletedUserId)
        {
            var result = _removePassengerCommand.Execute(tripId, deletedUserId);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }

        [HttpPut("{tripId}")]
        public IActionResult Update(Guid tripId, CreateAndUpdateTripModel createAndUpdateTripModel)
        {
            var result = _updateTripCommand.Execute(createAndUpdateTripModel, tripId);
            
            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }
    }
}