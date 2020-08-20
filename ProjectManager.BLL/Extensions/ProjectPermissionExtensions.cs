using ProjectManager.BLL.Models;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ProjectManager.BLL.Extensions
{
    internal static class ProjectPermissionExtensions
    {
        public static bool CanCreateProject(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader) || user.IsInRole(Roles.Manager);
        }
        public static bool CanEditProject(this ClaimsPrincipal user, ProjectModel project)
        {
            if (project == null)
                return false;

            var userId = user.GetLoggedInUserId<Guid>();

            return user.IsInRole(Roles.Leader) || project.ManagerId == userId;
        }
        public static bool CanLookAllProjects(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader);
        }
        public static bool CanLookProject(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }
        public static bool CanRemoveProject(this ClaimsPrincipal user, ProjectModel project)
        {
            return CanEditProject(user, project);
        }
    }
}
