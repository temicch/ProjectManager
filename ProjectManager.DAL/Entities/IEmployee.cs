using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        string Surname { get; }
        string Email { get; }
        List<Project> Projects { get; }
        List<Task> Tasks { get; }
    }
}
