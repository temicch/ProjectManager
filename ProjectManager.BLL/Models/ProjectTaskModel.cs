using System;
using ProjectManager.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.Models
{
    public class ProjectTaskModel
    {
        public Guid Id { get; private set; }

        [Required]
        public string Title { get; set; }
        public EmployeeModel Author { get; set; }
        public Guid AuthorId { get; set; }
        public EmployeeModel Performer { get; set; }
        public Guid PerformerId { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public ProjectModel Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}