﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IBaseEntity<int>
    {
        public Employee(string email) : base(email)
        {
            Email = email;

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

        public ICollection<ProjectEmployees> ProjectEmployees { get; set; }
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
        public override string ToString()
        {
            return string.Join(' ', LastName, FirstName, Surname);
        }
    }
}