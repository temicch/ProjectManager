namespace ProjectManager.DAL.Entities
{
    public class ProjectEmployees
    {
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}
