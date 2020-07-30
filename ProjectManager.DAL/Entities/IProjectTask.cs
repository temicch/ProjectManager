﻿namespace ProjectManager.DAL.Entities
{
    public interface IProjectTask
    {
        int Id { get; }

        string Title { get; }

        /// <summary>
        ///     Task Author
        /// </summary>
        Employee Author { get; }

        int? AuthorId { get; }

        /// <summary>
        ///     Task performer employee
        /// </summary>
        Employee Performer { get; }

        int? PerformerId { get; }

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

        int? ProjectId { get; }
    }
}