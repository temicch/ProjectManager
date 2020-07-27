using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IEmployee
    {
        string FirstName { get; }
        string LastName { get; }
        string Surname { get; }
        string Email { get; }
        ICollection<ProjectTask> Tasks { get; }
        string AvatarUrl { get; }
    }
}
