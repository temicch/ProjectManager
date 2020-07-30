using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IProject
    {
        int Id { get; }

        string Title { get; }
        string CustomerCompany { get; }
        string PerformerCompany { get; }

        /// <summary>
        ///     Project tasks
        /// </summary>
        ICollection<ProjectTask> Tasks { get; }

        /// <summary>
        ///     Project manager
        /// </summary>
        Employee Manager { get; }

        int? ManagerId { get; }

        /// <summary>
        ///     Project start date
        /// </summary>
        DateTime StartDate { get; }

        /// <summary>
        ///     Project completion date
        /// </summary>
        DateTime EndDate { get; }

        /// <summary>
        ///     Project priority
        /// </summary>
        uint Priority { get; }
    }
}