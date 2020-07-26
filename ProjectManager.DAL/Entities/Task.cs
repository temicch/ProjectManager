namespace ProjectManager.DAL.Entities
{
    public class Task : ITask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public string AuthorId { get; set; }
        public Employee Author { get; set; }
        public string PerformerId { get; set; }
        public Employee Performer { get; set; }
        public string ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
