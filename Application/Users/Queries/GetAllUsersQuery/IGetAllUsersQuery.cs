using System.Collections.Generic;
using Domain.Users;

namespace Application.Users.Queries.GetAllUsersQuery
{
    public interface IGetAllUsersQuery
    {
        IEnumerable<User> Execute();
    }
}