using System.Collections.Generic;
using System.Linq;
using API.Extensions;
using Application.Users.Commands.AddOrUpdateCarCommand;
using Application.Users.Commands.UpdateUserCommand;
using Application.Users.Queries.GetAllUsersQuery;
using Application.Users.Queries.GetUserInfoQuery;
using Domain.Cars;
using Domain.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IGetAllUsersQuery _getAllUsersQuery;
        private readonly IUpdateUserPhoneCommand _updateUserPhoneCommand;
        private readonly IAddOrUpdateCarCommand _addOrUpdateCarCommand;
        private readonly IGetUserInfoQuery _getUserInfoQuery;

        public UsersController(
            IGetAllUsersQuery getAllUsersQuery,
            IUpdateUserPhoneCommand updateUserPhoneCommand,
            IAddOrUpdateCarCommand addOrUpdateCarCommand,
            IGetUserInfoQuery getUserInfoQuery)
        {
            _getAllUsersQuery = getAllUsersQuery;
            _updateUserPhoneCommand = updateUserPhoneCommand;
            _addOrUpdateCarCommand = addOrUpdateCarCommand;
            _getUserInfoQuery = getUserInfoQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _getAllUsersQuery.Execute().ToList();
        }

        [HttpGet("me")]
        public ActionResult<User> GetMyInfo()
        {
            var userId = User.GetUserIdentifier();

            return _getUserInfoQuery.Execute(userId);
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