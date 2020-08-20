using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.DAL.Entities
{
    public class ProjectEmployees : IBaseEntity<Guid>
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }
        
        [NotMapped] public Guid Id { get; set; }
    }
}