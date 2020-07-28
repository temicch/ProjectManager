using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Project : IProject, IBaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public uint Priority { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
        public Employee Manager { get; set; }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
