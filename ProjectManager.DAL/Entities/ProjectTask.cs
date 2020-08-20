using System;

namespace ProjectManager.DAL.Entities
{
    public class ProjectTask: IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
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
        public Guid AuthorId { get; set; }

        /// <summary>
        ///     Task performer employee
        /// </summary>
        public virtual Employee Performer { get; set; }
        public Guid? PerformerId { get; set; }

        /// <summary>
        ///     Project task
        /// </summary>
        public virtual Project Project { get; set; }
        public Guid ProjectId { get; set; }
    }
}