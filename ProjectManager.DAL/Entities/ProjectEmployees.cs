using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entities
{
    public class ProjectEmployees
    {
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
