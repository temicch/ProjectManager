using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        string Surname { get; }
        string Email { get; }

        /// <summary>
        ///     Employee tasks
        /// </summary>
        ICollection<ProjectTask> Tasks { get; }

        /// <summary>
        ///     Tasks in which the employee is the author
        /// </summary>
        ICollection<ProjectTask> TasksAuthor { get; }

        /// <summary>
        ///     Projects in which the employee is the manager
        /// </summary>
        ICollection<Project> ManagedProjects { get; }
    }
}