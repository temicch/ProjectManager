using System.ComponentModel.DataAnnotations;

namespace ProjectManager.DAL.Entities
{
    public class ProjectTask: IBaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        /// <summary>
        ///     Task status
        /// </summary>
        public TaskStatus Status { get; set; }
        /// <summary>
        ///     Comment
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        ///     Task priority
        /// </summary>
        public ushort Priority { get; set; }

        /// <summary>
        ///     Task Author
        /// </summary>
        public virtual Employee Author { get; set; }
        public int AuthorId { get; set; }

        /// <summary>
        ///     Task performer employee
        /// </summary>
        public Employee Performer { get; set; }
        public int? PerformerId { get; set; }

        /// <summary>
        ///     Project task
        /// </summary>
        public Project Project { get; set; }
        public int ProjectId { get; set; }
    }
}