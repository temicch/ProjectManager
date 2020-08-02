using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.BLL.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<ProjectTaskModel> Tasks { get; set; }
    }
}