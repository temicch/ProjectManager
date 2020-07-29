namespace ProjectManager.DAL.Entities
{
    public class ProjectTask : IProjectTask, IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public Employee Author { get; set; }
        public int AuthorId { get; set; }
        public Employee Performer { get; set; }
        public int PerformerId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}