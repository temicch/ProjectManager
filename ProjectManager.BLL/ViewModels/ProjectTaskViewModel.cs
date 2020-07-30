using ProjectManager.DAL.Entities;

namespace ProjectManager.BLL.ViewModels
{
    public class ProjectTaskViewModel
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public EmployeeViewModel Author { get; set; }
        public int AuthorId { get; set; }
        public EmployeeViewModel Performer { get; set; }
        public int PerformerId { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public ProjectViewModel Project { get; set; }
        public int ProjectId { get; set; }
    }
}