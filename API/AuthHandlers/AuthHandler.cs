using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Extensions;
using Application.Interfaces.Persistence;
using Domain.Users;
using Microsoft.AspNetCore.Authorization;

namespace API.AuthHandlers
{
    public class UserExist : IAuthorizationRequirement { }

    public class AuthHandler : AuthorizationHandler<UserExist>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AuthHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserExist requirement)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var nameIdentifier = context.User.GetUserIdentifier();

                var user = _userRepository.Get(nameIdentifier);

                if (user == null)
                {
                    var firstName = GetStringClaim(context, ClaimTypes.GivenName, string.Empty);
                    var lastName = GetStringClaim(context, ClaimTypes.Surname, string.Empty);

                    var newUser = new User(firstName, lastName);
                    newUser.AddId(nameIdentifier);

                    _userRepository.Add(newUser);

                    _unitOfWork.Save();
                }

                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }

        private static string GetStringClaim(AuthorizationHandlerContext context, string claimName, string defaultValue)
        {
            return context.User.Claims
                .FirstOrDefault(x => x.Type.Equals(claimName))?
                .Value ?? defaultValue;
        }
    }
}