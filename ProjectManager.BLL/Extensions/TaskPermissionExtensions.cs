using ProjectManager.BLL.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ProjectManager.BLL.Extensions
{
    internal static class TaskPermissionExtensions
    {
        public static bool CanCreateTask(this ClaimsPrincipal user, ProjectTaskModel projectTask)
        {
            var userId = user.GetLoggedInUserId<Guid>();

            return user.IsInRole(Roles.Leader) || projectTask.Project.ManagerId == userId;
        }
        public static bool CanEditTask(this ClaimsPrincipal user, ProjectTaskModel task)
        {
            if (task == null)
                return false;

            var userId = user.GetLoggedInUserId<Guid>();

            return user.IsInRole(Roles.Leader) || task.AuthorId == userId;
        }
        public static bool CanChangeTaskStatus(this ClaimsPrincipal user, ProjectTaskModel task)
        {
            if (task == null)
                return false;

            var userId = user.GetLoggedInUserId<Guid>();

            return user.IsInRole(Roles.Leader) || task.AuthorId == userId || task.PerformerId == userId;
        }
        public static bool CanRemoveTask(this ClaimsPrincipal user, ProjectTaskModel task)
        {
            return CanEditTask(user, task);
        }
        public static bool CanLookAllTasks(this ClaimsPrincipal user)
        {
            return user.IsInRole(Roles.Leader);
        }
        public static bool CanLookTask(this ClaimsPrincipal user)
        {
            return user.Identity.IsAuthenticated;
        }
    }
}
