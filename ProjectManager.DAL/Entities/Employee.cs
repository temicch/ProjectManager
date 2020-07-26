using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser, IEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }

        public List<Project> Projects { get; set; }
        public List<Task> Tasks { get; set; }
    }
}
