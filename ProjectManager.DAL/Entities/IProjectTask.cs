using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public interface IProjectTask
    {
        int Id { get; }
        string Title { get; }
        Employee Author { get; }
        Employee Performer { get; }
        TaskStatus Status { get; }
        string Comment { get; }
        uint Priority { get; }
        Project Project { get; }
    }
}
