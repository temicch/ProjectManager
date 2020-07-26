using Microsoft.AspNetCore.Identity;

namespace ProjectManager.DAL.Entities
{
    public interface ITask
    {
        int Id { get; }
        string Title { get; }
        string AuthorId { get; }
        Employee Author { get; }
        string PerformerId { get; }
        Employee Performer { get; }
        TaskStatus Status { get; }
        string Comment { get; }
        uint Priority { get; }
    }
}
