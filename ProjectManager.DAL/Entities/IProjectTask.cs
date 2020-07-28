using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public interface IProjectTask
    {
        int Id { get; }

        /// <summary>
        ///     Task title
        /// </summary>
        string Title { get; }

        /// <summary>
        ///     Task Author
        /// </summary>
        Employee Author { get; }

        /// <summary>
        ///     Task performer employee
        /// </summary>
        Employee Performer { get; }

        /// <summary>
        ///     Task status
        /// </summary>
        TaskStatus Status { get; }

        /// <summary>
        ///     Comment
        /// </summary>
        string Comment { get; }

        /// <summary>
        ///     Task priority
        /// </summary>
        uint Priority { get; }

        /// <summary>
        ///     Project task
        /// </summary>
        Project Project { get; }
    }
}