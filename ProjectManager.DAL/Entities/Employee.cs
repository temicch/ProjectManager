using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IEmployee
    {
        public Employee(): base()
        {
        }

        public Employee(string userName): base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }

        public string AvatarUrl { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Project> ManagedProjects { get; set; }

        public ICollection<ProjectTask> TasksAuthor { get; set; }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
