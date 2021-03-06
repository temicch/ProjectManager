﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.PL.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "Id")] 
        public Guid Id { get; set; }

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

        [Display(Name = "Name")] 
        public string FullName => GetFullName();

        [Display(Name = "Name")] 
        public string SimplifiedName => GetSimplifiedName();

        private string GetFullName()
        {
            return string.Join(" ", LastName ?? string.Empty, FirstName ?? string.Empty, Surname ?? string.Empty);
        }

        private string GetSimplifiedName()
        {
            var _FirstName = FirstName?.Length > 1 ? $"{FirstName.Substring(0, 1).ToUpper()}." : null;
            var _Surname = Surname?.Length > 1 ? $"{Surname.Substring(0, 1).ToUpper()}." : null;
            return string.Join(" ", LastName ?? string.Empty, _FirstName ?? string.Empty, _Surname ?? string.Empty);
        }
    }
}