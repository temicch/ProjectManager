using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.BLL.ViewModels
{
    public class ProjectViewModel : IProject
    {
        private IProject project;
        public ProjectViewModel()
        {
        }
        public ProjectViewModel(int Id)
        {
            this.Id = Id;
        }

        public ProjectViewModel(IProject project)
        {
            if (project == null)
                return;
            Id = project?.Id ?? 0;
            Title = project?.Title;
            CustomerCompany = project?.CustomerCompany;
            PerformerCompany = project?.PerformerCompany;
            Tasks = project?.Tasks;
            Manager = project?.Manager;
            StartDate = project?.StartDate ?? DateTime.Now;
            EndDate = project?.EndDate ?? DateTime.Now;
            Priority = project?.Priority ?? 0;
        }

        public ICollection<ProjectTaskViewModel> TasksViewModels => project?.Tasks?.Select(x => new ProjectTaskViewModel(x))?.ToList();
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint Priority { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public Employee Manager { get; set; }
        }
}