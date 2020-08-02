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
        public async Task<IActionResult> Index()
        {
            var tasksViewModels = await TaskService.GetAllAsync(User);
            return View(tasksViewModels);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var task = await TaskService.GetAsync(User, id);
            if (task == null) return NotFound();
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
                await TaskService.CreateAsync(User, Mapper.Map<ProjectTaskModel>(projectTask));

                return RedirectToAction("Index", new {projectTask.Id});
            }

            return View(projectTask);
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
                await TaskService.EditAsync(User, Mapper.Map<ProjectTaskModel>(projectTask));

                return RedirectToAction("Index", new {projectTask.Id});
            }

            return View(projectTask);
        }
    }
}