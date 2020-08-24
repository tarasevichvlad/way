using Application.Interfaces.Persistence;
using Domain.Users;
using Persistence.Shared;

namespace Persistence.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}