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
        ICollection<ProjectTask> Tasks { get; }
        Employee Manager { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        uint Priority { get; }
    }
}
