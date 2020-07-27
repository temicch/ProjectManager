using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser<int>, IEmployee
    {
        public Employee()
        {
            //Tasks = new HashSet<Task>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
