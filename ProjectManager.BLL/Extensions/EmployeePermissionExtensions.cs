using System.Security.Claims;

namespace ProjectManager.BLL.Extensions
{
    internal static partial class EmployeePermissionExtensions
    {
        public static bool CanCreateEmployee(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader);
        }
        public static bool CanRemoveEmployee(this ClaimsPrincipal user)
        {
            return CanCreateEmployee(user);
        }
        public static bool CanLookAllEmployees(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader) || user.IsInRole(Roles.Manager);
        }
        public static bool CanLookEmployee(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }
        public static bool CanEditEmployee(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader);
        }
    }
}
