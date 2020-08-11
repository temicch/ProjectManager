using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.PL.ViewModels
{
    public class ProjectViewModel
    {
        public ICollection<ProjectTaskViewModel> TasksViewModels { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        [Display(Name = "Customer Company")] 
        public string CustomerCompany { get; set; }

        [Display(Name = "Performer Company")] 
        public string PerformerCompany { get; set; }

        [Display(Name = "Start Date")] 
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")] 
        public DateTime EndDate { get; set; }

        public uint Priority { get; set; }
        public ICollection<ProjectTaskViewModel> Tasks { get; set; }
        public EmployeeViewModel Manager { get; set; }
        public int ManagerId { get; set; }
    }
}