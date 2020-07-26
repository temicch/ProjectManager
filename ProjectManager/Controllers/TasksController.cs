using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;

namespace TaskBud.Website.Controllers
{
    [Authorize]
    [Route("tasks")]
    public class TasksController : Controller
    {
        private ITaskManager TaskManager { get; }
        private IProjectManager ProjectManager { get; }

        public TasksController(ITaskManager taskManager, IProjectManager projectManager)
        {
            TaskManager = taskManager ?? throw new ArgumentNullException(nameof(taskManager));
            ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(taskManager));
        }

        [HttpGet("index")]
        public IActionResult Index(int projectId)
        {
            var project = ProjectManager.Get(projectId).Result;
            var task = project.Tasks.Select(x => new TaskViewModel(x));

            return View(task);
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
            var data = new TaskViewModel{ ProjectId = projectId };
            return View(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TaskViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await TaskManager.CreateAsync(User, writeData);

                return RedirectToAction("Index", new { writeData.Id });
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
        public async Task<IActionResult> Update(TaskViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await TaskManager.EditAsync(writeData);

                return RedirectToAction("Index", new { writeData.Id });
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
