using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.Models
{
    public class ProjectModel
    {
        public ICollection<ProjectTaskModel> TasksViewModels { get; set; }
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string CustomerCompany { get; set; }

        [Required]
        public string PerformerCompany { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public uint Priority { get; set; }
        public ICollection<ProjectTaskModel> Tasks { get; set; }
        public EmployeeModel Manager { get; set; }
        public int? ManagerId { get; set; }
    }
}