using ProjectManager.DAL.Entities;
using System.Collections.Generic;

namespace ProjectManager.BLL.Services
{
    interface ITaskManager
    {
        IEnumerable<ITask> GetAll(IProject project);
        IEnumerable<ITask> GetByEmployee(IProject project, IEmployee employee);
        bool Create(IProject project, ITask task);
        bool Edit(ITask newTask);
        bool Remove(string id);
    }
}
