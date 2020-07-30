namespace ProjectManager.DAL.Entities
{
    public class ProjectTask : IProjectTask, IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public virtual Employee Author { get; set; }
        public int? AuthorId { get; set; }
        public virtual Employee Performer { get; set; }
        public int? PerformerId { get; set; }
        public virtual Project Project { get; set; }
        public int? ProjectId { get; set; }
    }
}