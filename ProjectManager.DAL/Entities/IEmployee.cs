using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IEmployee
    {
        /// <summary>
        /// Employee First Name
        /// </summary>
        string FirstName { get; }
        /// <summary>
        /// Employee Last Name
        /// </summary>
        string LastName { get; }
        /// <summary>
        /// Employee Surname
        /// </summary>
        string Surname { get; }
        /// <summary>
        /// Employee Email
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Employee tasks
        /// </summary>
        ICollection<ProjectTask> Tasks { get; }
        /// <summary>
        /// Tasks in which the employee is the author
        /// </summary>
        ICollection<ProjectTask> TasksAuthor { get; }
        /// <summary>
        /// Projects in which the employee is the manager
        /// </summary>
        ICollection<Project> ManagedProjects { get; }
        /// <summary>
        /// Employee avatar link
        /// </summary>
        string AvatarUrl { get; }
    }
}
