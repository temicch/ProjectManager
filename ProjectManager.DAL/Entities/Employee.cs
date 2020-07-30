using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IEmployee, IBaseEntity
    {
        public Employee(string email) : base(email)
        {
            Email = email;
        }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public ICollection<Project> ManagedProjects { get; set; }
        public ICollection<ProjectTask> TasksAuthor { get; set; }
    }
}