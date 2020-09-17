using System.Collections.Generic;
using System.Linq;
using Application.Users.Queries.GetAllUsersQuery;
using Domain.Users;
using Microsoft.AspNetCore.Mvc;

namespace API.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IGetAllUsersQuery _getAllUsersQuery;

        public UserController(IGetAllUsersQuery getAllUsersQuery)
        {
            _getAllUsersQuery = getAllUsersQuery;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            return _getAllUsersQuery.Execute().ToList();
        }
    }
}