using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IEmployee, IBaseEntity
    {
        public Employee() : base()
        {
        }

        public Employee(string email) : base(email)
        {
            UserName = email;
        }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public string AvatarUrl { get; set; }
        public ICollection<Project> ManagedProjects { get; set; }
        public ICollection<ProjectTask> TasksAuthor { get; set; }
    }
}