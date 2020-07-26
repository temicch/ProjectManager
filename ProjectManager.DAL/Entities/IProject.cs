using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public interface IProject
    {
        int Id { get; }
        string Title { get; }
        string CustomerCompany { get; }
        string PerformerCompany { get; }
        //ICollection<Employee> Employees { get; }
        ICollection<Task> Tasks { get; }
        string ManagerId { get; }
        Employee Manager { get; }
        DateTime Start { get; }
        DateTime End { get; }
        uint Priority { get; }
    }
}
