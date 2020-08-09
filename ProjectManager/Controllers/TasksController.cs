using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.BLL.Models;
using ProjectManager.BLL.Services;
using ProjectManager.ViewModels;

namespace ProjectManager.PL.Controllers
{
    public class TasksController : Controller
    {
        public TasksController(ITaskService taskService,
            IMapper mapper)
        {
            TaskService = taskService;
            Mapper = mapper;
        }

        private ITaskService TaskService { get; }
        private IMapper Mapper { get; }

        // GET: Tasks
        public IActionResult Index()
        {
            var tasks = TaskService.GetAll(User);
            return View(Mapper.Map<IEnumerable<ProjectTaskViewModel>>(tasks));
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await TaskService.GetAsync(User, id);
            if (task == null) 
                return NotFound();
            return View(Mapper.Map<ProjectTaskViewModel>(task));
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            var task = new ProjectTaskViewModel();
            return View(task);
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectTaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                await TaskService.CreateAsync(User, Mapper.Map<ProjectTaskModel>(task));

                return RedirectToAction("Index", new {task.Id});
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var task = await TaskService.GetAsync(User, id);
            return View(Mapper.Map<ProjectTaskViewModel>(task));
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectTaskViewModel task)
        {
            if (ModelState.IsValid)
            {
                await TaskService.EditAsync(User, Mapper.Map<ProjectTaskModel>(task));

                return RedirectToAction("Index", new {task.Id});
            }

            return View(task);
        }
    }
}