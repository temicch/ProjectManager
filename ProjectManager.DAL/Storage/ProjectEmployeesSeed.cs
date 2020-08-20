using ProjectManager.DAL.Entities;
using System.Collections.Generic;

namespace ProjectManager.DAL.Storage
{
    internal static class ProjectEmployeesSeed
    {
        public static ICollection<ProjectEmployees> ProjectEmployees { get; set; }

        static ProjectEmployeesSeed()
        {
            
        }
    }
}
