using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.BLL.ViewModels
{
    public class ProjectViewModel
    {
        public ICollection<ProjectTaskViewModel> TasksViewModels { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint Priority { get; set; }
        public ICollection<ProjectTaskViewModel> Tasks { get; set; }
        public EmployeeViewModel Manager { get; set; }
    }
}