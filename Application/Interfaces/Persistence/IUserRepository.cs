using System;
using Domain.Users;

namespace Application.Interfaces.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserWithCarById(Guid userId);
    }
}