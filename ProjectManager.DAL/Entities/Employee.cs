using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IBaseEntity
    {
        public Employee(string email) : base(email)
        {
            Email = email;
        }

        public ICollection<ProjectEmployees> ProjectEmployees { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Surname { get; set; }
        /// <summary>
        ///     Employee tasks
        /// </summary>
        public ICollection<ProjectTask> Tasks { get; set; }
        /// <summary>
        ///     Projects in which the employee is the manager
        /// </summary>
        public ICollection<Project> ManagedProjects { get; set; }
        /// <summary>
        ///     Tasks in which the employee is the author
        /// </summary>
        public ICollection<ProjectTask> TasksAuthor { get; set; }
    }
}