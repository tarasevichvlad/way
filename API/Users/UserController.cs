using System.Collections.Generic;
using System.Linq;
using API.Extensions;
using Application.Users.Commands.AddOrUpdateCarCommand;
using Application.Users.Commands.UpdateUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Domain.Cars;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersQuery _getAllUsersQuery;
        private readonly IUpdateUserPhoneCommand _updateUserPhoneCommand;
        private readonly IAddOrUpdateCarCommand _addOrUpdateCarCommand;

        public UserController(
            IGetAllUsersQuery getAllUsersQuery,
            IUpdateUserPhoneCommand updateUserPhoneCommand,
            IAddOrUpdateCarCommand addOrUpdateCarCommand)
        {
            _getAllUsersQuery = getAllUsersQuery;
            _updateUserPhoneCommand = updateUserPhoneCommand;
            _addOrUpdateCarCommand = addOrUpdateCarCommand;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _getAllUsersQuery.Execute().ToList();
        }

        [HttpPost("phone")]
        public ActionResult AddOrUpdateUserPhone(string phone)
        {
            var userId = User.GetUserIdentifier();

            var result = _updateUserPhoneCommand.Execute(userId, phone);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }

        [HttpPost("car")]
        public ActionResult AddOrUpdateCarCommand([FromBody] Car car)
        {
            var userId = User.GetUserIdentifier();

            var result = _addOrUpdateCarCommand.Execute(userId, car);

            return result.IsSuccess ? (ActionResult) StatusCode(StatusCodes.Status200OK) : BadRequest(result.Errors);
        }
    }
}