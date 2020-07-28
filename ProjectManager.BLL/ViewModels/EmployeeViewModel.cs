using System.Collections.Generic;

namespace ProjectManager.BLL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public ICollection<ProjectTaskViewModel> Tasks { get; set; }
        public string AvatarUrl { get; set; }
    }
}