using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;

namespace ProjectManager.Controllers
{
    [Authorize]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        public ProjectsController(IProjectManager projectManager)
        {
            ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
        }

        private IProjectManager ProjectManager { get; }

        [HttpGet("index")]
        public async Task<IActionResult> Index(int projectId)
        {
            var projectsViewModels = ProjectManager.GetAll();

            //var id = await ProjectManager.CreateAsync(User, new ProjectViewModel()
            //{
            //    CustomerCompany = "Sibers",
            //    EndDate = DateTime.Now,
            //    StartDate = DateTime.Now,
            //    PerformerCompany = "Fin Pack",
            //    Priority = 300,
            //    Title = "Make DB"
            //});

            return View(projectsViewModels);
        }

        [HttpGet("{taskId}")]
        public IActionResult Read(int projectId)
        {
            var readData = ProjectManager.Get(projectId).Result;
            return PartialView("_ProjectItem", readData);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var data = new ProjectViewModel();
            return View(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProjectViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.CreateAsync(User, writeData);

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
            var data = await ProjectManager.Get(id);
            return View(data);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(ProjectViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.EditAsync(writeData);

                return RedirectToAction("Index", new {writeData.Id});
            }
            else
            {
                return View(writeData);
            }
        }
    }
}