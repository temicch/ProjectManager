using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<Guid>, IBaseEntity<Guid>
    {
        public Employee(string email) : base(email)
        {
            Email = email;
            EmailConfirmed = true;

            ProjectEmployees = new HashSet<ProjectEmployees>();
            Tasks = new HashSet<ProjectTask>();
            ManagedProjects = new HashSet<Project>();
            TasksAuthor = new HashSet<ProjectTask>();

            FirstName = string.Empty;
            LastName = string.Empty;
            Surname = string.Empty;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
        /// <summary>
        ///     Employee tasks
        /// </summary>
        public virtual ICollection<ProjectTask> Tasks { get; set; }
        /// <summary>
        ///     Projects in which the employee is the manager
        /// </summary>
        public virtual ICollection<Project> ManagedProjects { get; set; }
        /// <summary>
        ///     Tasks in which the employee is the author
        /// </summary>
        public virtual ICollection<ProjectTask> TasksAuthor { get; set; }
        public override string ToString()
        {
            return string.Join(' ', LastName, FirstName, Surname);
        }
    }
}