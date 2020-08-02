using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entities
{
    public class Project : IBaseEntity
    {
        public int Id { get; set; }
        [Required]
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
        public DateTime? EndDate { get; set; }
        /// <summary>
        ///     Project priority
        /// </summary>
        public ushort Priority { get; set; }
        /// <summary>
        ///     Project tasks
        /// </summary>
        public ICollection<ProjectTask> Tasks { get; set; }

        /// <summary>
        ///     Project manager
        /// </summary>
        public Employee Manager { get; set; }
        public int? ManagerId { get; set; }

        public ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}