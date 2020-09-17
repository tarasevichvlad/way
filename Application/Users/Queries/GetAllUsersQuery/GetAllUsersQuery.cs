using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAllUsersQuery
{
    public class GetAllUsersQuery : IGetAllUsersQuery
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> Execute()
        {
            return _userRepository
                .GetAll()
                .Include(x => x.Car)
                .ToList();
        }
    }
}