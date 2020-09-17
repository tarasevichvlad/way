using System;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public User GetUserWithCarById(Guid userId)
        {
            return DbSet
                .Include(x => x.Car)
                .FirstOrDefault(x => x.Id.Equals(userId));
        }
    }
}