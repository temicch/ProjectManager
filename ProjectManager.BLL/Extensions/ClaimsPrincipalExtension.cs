using System;
using System.Security.Claims;

namespace ProjectManager.BLL.Extensions
{
    internal static class ClaimsPrincipalExtension
    {
        public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInUserId == null)
                return default;

            if (typeof(T) == typeof(Guid))
                return (T) Convert.ChangeType(Guid.Parse(loggedInUserId), typeof(T));
            if (typeof(T) == typeof(string) || typeof(T) == typeof(Guid))
                return (T) Convert.ChangeType(loggedInUserId, typeof(T));
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
                return loggedInUserId != null
                    ? (T) Convert.ChangeType(loggedInUserId, typeof(T))
                    : (T) Convert.ChangeType(0, typeof(T));
            throw new Exception("Invalid type provided");
        }
    }
}