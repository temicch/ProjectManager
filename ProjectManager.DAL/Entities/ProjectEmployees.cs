using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.DAL.Entities
{
    public class ProjectEmployees : IBaseEntity<int>
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        
        [NotMapped] public int Id { get; set; }
    }
}