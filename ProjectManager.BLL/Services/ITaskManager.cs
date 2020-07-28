﻿using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.BLL.Services
{
    public interface ITaskManager
    {
        Task<IEnumerable<ProjectTaskViewModel>> GetAll();
        Task<IEnumerable<ProjectTaskViewModel>> GetByEmployee(int employeeId);
        Task<ProjectTaskViewModel> Get(int id);
        Task<int> CreateAsync(ClaimsPrincipal user, ProjectTaskViewModel data);
        Task<int> EditAsync(ProjectTaskViewModel task);
        Task<bool> Remove(int id);
    }
}