using ProjectManager.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.BLL.Services
{
    class TaskManager : ITaskManager
    {
        public bool Create(IProject project, ITask task)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ITask newTask)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetAll(IProject project)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITask> GetByEmployee(IProject project, IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string id)
        {
            throw new NotImplementedException();
        }
    }
}
