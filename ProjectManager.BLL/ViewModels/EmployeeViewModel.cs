using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Tasks")]
        public ICollection<ProjectTaskViewModel> Tasks { get; set; }
        [Display(Name = "Avatar")]
        public string AvatarUrl { get; set; }
    }
}