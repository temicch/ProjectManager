using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entities
{
    public class ProjectTask : IProjectTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public Employee Author { get; set; }
        public Employee Performer { get; set; }
        public Project Project { get; set; }
    }
}
