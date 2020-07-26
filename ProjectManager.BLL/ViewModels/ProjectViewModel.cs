using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;

namespace ProjectManager.BLL.ViewModels
{
    public class ProjectViewModel : IProject
    {
        public ProjectViewModel()
        {

        }
        public ProjectViewModel(int Id)
        {
            this.Id = Id;
        }

        public ProjectViewModel(IProject project)
        {
            Id = project.Id;
            Title = project.Title;
            CustomerCompany = project.CustomerCompany;
            PerformerCompany = project.PerformerCompany;
            Start = project.Start;
            End = project.End;
            Priority = project.Priority;
            Tasks = project.Tasks;
            ManagerId = project.ManagerId;
            Manager = project.Manager;
        }

        public ICollection<TaskViewModel> TasksViewModels { get; set; }

        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public uint Priority { get; set; }
        public ICollection<Task> Tasks { get; set; }
        public string ManagerId { get; set; }
        public Employee Manager { get; set; }
    }
}