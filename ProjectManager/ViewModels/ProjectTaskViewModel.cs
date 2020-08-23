using System;
using ProjectManager.DAL.Entities;

namespace ProjectManager.PL.ViewModels
{
    public class ProjectTaskViewModel
    {
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public EmployeeViewModel Author { get; set; }
        public Guid AuthorId { get; set; }
        public EmployeeViewModel Performer { get; set; }
        public Guid PerformerId { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public uint Priority { get; set; }
        public ProjectViewModel Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}