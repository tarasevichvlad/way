using System;
using Domain.Users;

namespace Application.Users.Queries.GetUserInfoQuery
{
    public interface IGetUserInfoQuery
    {
        User Execute(Guid userId);
    }
}