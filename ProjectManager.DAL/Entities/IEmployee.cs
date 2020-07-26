using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        string Surname { get; }
        string Email { get; }
        //ICollection<Project> Projects { get; }
        ICollection<Task> Tasks { get; }
    }
}
