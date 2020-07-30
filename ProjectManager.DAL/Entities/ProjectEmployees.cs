using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.DAL.Entities
{
    public class ProjectEmployees: IBaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        [NotMapped]
        public int Id { get; set; }
    }
}