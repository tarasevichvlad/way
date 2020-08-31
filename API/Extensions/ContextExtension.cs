using System;
using System.Linq;
using System.Security.Claims;

namespace API.Extensions
{
    public static class ContextExtension
    {
        public static Guid GetUserIdentifier(this ClaimsPrincipal principal)
        {
            if (!principal.Identity.IsAuthenticated) return Guid.Empty;

            var userId = principal.Claims
                .FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier))?
                .Value;

            return Guid.Parse(userId);
        }
    }
}