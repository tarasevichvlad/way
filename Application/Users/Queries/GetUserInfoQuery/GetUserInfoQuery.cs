using System;
using Application.Interfaces.Persistence;
using Domain.Users;

namespace Application.Users.Queries.GetUserInfoQuery
{
    public class GetUserInfoQuery : IGetUserInfoQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Execute(Guid userId)
        {
            return _userRepository.Get(userId);
        }
    }
}