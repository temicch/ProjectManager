using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;

namespace ProjectManager.PL.Controllers
{
    public class TasksController : Controller
    {
        private ITaskService TaskService { get; }

        public TasksController(ITaskService taskService)
        {
            TaskService = taskService;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            var tasksViewModels = await TaskService.GetAllAsync(User);
            return View(tasksViewModels);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await TaskService.GetAsync(User, id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            var data = new ProjectTaskViewModel();
            return View(data);
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectTaskViewModel projectTask)
        {
            if (ModelState.IsValid)
            {
                await TaskService.CreateAsync(User, projectTask);

                return RedirectToAction("Index", new { projectTask.Id });
            }
            else
            {
                return View(projectTask);
            }
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var data = await TaskService.GetAsync(User, id);
            return View(data);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectTaskViewModel projectTask)
        {
            if (ModelState.IsValid)
            {
                await TaskService.EditAsync(User, projectTask);

                return RedirectToAction("Index", new { projectTask.Id });
            }
            else
            {
                return View(projectTask);
            }
        }
    }
}
