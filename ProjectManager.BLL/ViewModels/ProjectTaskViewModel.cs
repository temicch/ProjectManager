using ProjectManager.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.ViewModels
{
    public class ProjectTaskViewModel: IProjectTask
    {
        public ProjectTaskViewModel()
        {
        }
        public ProjectTaskViewModel(int Id)
        {
            this.Id = Id;
        }
        public ProjectTaskViewModel(IProjectTask task)
        {
            if (task == null)
                return;
            Id = task?.Id ?? 0;
            Title = task?.Title;
            Author = task?.Author;
            Performer = task?.Performer;
            Status = task?.Status ?? TaskStatus.ToDo;
            Comment = task?.Comment;
            Priority = task?.Priority ?? 0;
            Project = task?.Project;
        }

        public int Id { get; private set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public Employee Author { get; set; }
        [Required]
        public Employee Performer { get; set; }
        [Required]
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        [Required]
        public uint Priority { get; set; }
        [Required]
        public Project Project { get; set; }
    }
}
