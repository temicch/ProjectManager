using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public class Employee : IdentityUser, IEmployee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Surname { get; set; }
    }
}
