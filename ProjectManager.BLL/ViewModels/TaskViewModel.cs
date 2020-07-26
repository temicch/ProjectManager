using ProjectManager.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.ViewModels
{
    public class TaskViewModel: ITask
    {
        public TaskViewModel()
        {

        }
        public TaskViewModel(int Id)
        {
            this.Id = Id;
        }
        public TaskViewModel(ITask task)
        {
            Id = task.Id;
            Title = task.Title;
            AuthorId = task.AuthorId;
            Author = task.Author;
            PerformerId = task.PerformerId;
            Performer = task.Performer;
            Status = task.Status;
            Comment = task.Comment;
            Priority = task.Priority;
            ProjectId = task.ProjectId;
            Project = task.Project;
        }

        public int Id { get; private set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public string AuthorId { get; set; }
        [Required]
        public Employee Author { get; set; }
        [Required]
        public string PerformerId { get; set; }
        [Required]
        public Employee Performer { get; set; }
        [Required]
        public TaskStatus Status { get; set; }

        public string Comment { get; set; }
        [Required]
        public uint Priority { get; set; }
        [Required]
        public string ProjectId { get; set; }
        [Required]
        public Project Project { get; set; }

        
    }
}
