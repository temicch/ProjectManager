using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;

namespace ProjectManager.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        public TasksController(
            ITaskManager taskManager,
            IProjectManager projectManager,
            IEmployeeManager employeeManager)
        {
            TaskManager = taskManager ?? throw new ArgumentNullException(nameof(taskManager));
            ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
            EmployeeManager = employeeManager ?? throw new ArgumentNullException(nameof(employeeManager));
        }

        private ITaskManager TaskManager { get; }
        private IProjectManager ProjectManager { get; }
        public IEmployeeManager EmployeeManager { get; }

        [HttpGet("index")]
        public async Task<IActionResult> Index(int projectId)
        {
            //var list = await EmployeeManager.Get(1);
            var projectsViewModels = ProjectManager.GetAll();

            var id = await ProjectManager.CreateAsync(User, new ProjectViewModel()
            {
                CustomerCompany = "Sibers",
                EndDate = DateTime.Now,
                StartDate = DateTime.Now,
                PerformerCompany = "Fin Pack",
                Priority = 300,
                Title = "Make DB"
            });

            return View(projectsViewModels);
        }

        [HttpGet("{taskId}")]
        public IActionResult Read(int taskId)
        {
            var readData = TaskManager.Get(taskId);
            return PartialView("_TaskItem", readData);
        }

        [HttpGet("create")]
        public IActionResult Create(string projectId)
        {
            var data = new ProjectViewModel();
            return View(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProjectTaskViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await TaskManager.CreateAsync(User, writeData);

                return RedirectToAction("Index", new {writeData.Id});
            }
            else
            {
                return View(writeData);
            }
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var data = await TaskManager.Get(id);
            return View(data);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(ProjectTaskViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await TaskManager.EditAsync(writeData);

                return RedirectToAction("Index", new {writeData.Id});
            }
            else
            {
                return View(writeData);
            }
        }

        //[HttpPost("{taskId}/assign/{userId?}")]
        //public async Task<IActionResult> Assign(string taskId, string userId)
        //{ 
        //    userId ??= User.GetLoggedInUserId<string>();

        //    await TaskManager.Assign(User, taskId, userId);

        //    return Ok();
        //}

        //[HttpPost("{taskId}/un-assign")]
        //public async Task<IActionResult> UnAssign(string taskId)
        //{
        //    await TaskManager.UnAssign(User, taskId);

        //    return Ok();
        //}

        //[HttpPost("{taskId}/complete")]
        //public async Task<IActionResult> Complete(string taskId)
        //{
        //    await TaskManager.Complete(User, taskId);

        //    return Ok();
        //}
    }
}