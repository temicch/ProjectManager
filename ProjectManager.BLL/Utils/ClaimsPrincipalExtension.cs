using System;
using System.Security.Claims;

namespace ProjectManager.BLL.Utils
{
    internal static class ClaimsPrincipalExtension
    {
        public static T GetLoggedInUserId<T>(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            var loggedInUserId = principal.FindFirstValue(ClaimTypes.NameIdentifier);

            if (typeof(T) == typeof(string))
                return (T) Convert.ChangeType(loggedInUserId, typeof(T));
            if (typeof(T) == typeof(int) || typeof(T) == typeof(long))
                return loggedInUserId != null
                    ? (T) Convert.ChangeType(loggedInUserId, typeof(T))
                    : (T) Convert.ChangeType(0, typeof(T));
            throw new Exception("Invalid type provided");
        }
    }
}