using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Project : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        /// <summary>
        ///     Project start date
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        ///     Project completion date
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        ///     Project priority
        /// </summary>
        public ushort Priority { get; set; }
        /// <summary>
        ///     Project tasks
        /// </summary>
        public virtual ICollection<ProjectTask> Tasks { get; set; }

        /// <summary>
        ///     Project manager
        /// </summary>
        public virtual Employee Manager { get; set; }
        public Guid? ManagerId { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }

        public Project()
        {
            ProjectEmployees = new HashSet<ProjectEmployees>();
            Tasks = new HashSet<ProjectTask>();
        }
    }
}