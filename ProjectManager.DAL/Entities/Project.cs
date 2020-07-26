using System;
using System.Collections.Generic;

namespace ProjectManager.DAL.Entities
{
    public class Project : IProject
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CustomerCompany { get; set; }
        public string PerformerCompany { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public uint Priority { get; set; }

        //public ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public string ManagerId { get; set; }
        public Employee Manager { get; set; }

        internal ICollection<ProjectEmployees> ProjectEmployees { get; set; }

        public Project()
        {
            //Tasks = new HashSet<Task>();
            //Employees = new HashSet<Employee>();
        }
    }
}
