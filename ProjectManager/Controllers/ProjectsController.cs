using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.BLL.Models;
using ProjectManager.BLL.Services;
using ProjectManager.ViewModels;

namespace ProjectManager.Controllers
{
    [Authorize]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        public ProjectsController(
            IProjectService projectManager,
            IMapper mapper
        )
        {
            ProjectService = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
            Mapper = mapper;
        }

        private IProjectService ProjectService { get; }
        private IMapper Mapper { get; }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            var projects = await ProjectService.GetAllAsync(User);

            return View(Mapper.Map<IEnumerable<ProjectViewModel>>(projects));
        }

        [HttpGet("details")]
        public async Task<IActionResult> Details(int id)
        {
            var project = await ProjectService.GetAsync(User, id);
            if (project == null) 
                return NotFound();
            return View(Mapper.Map<ProjectViewModel>(project));
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            var data = new ProjectViewModel();
            return View(data);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                await ProjectService.CreateAsync(User, Mapper.Map<ProjectModel>(project));

                return RedirectToAction("Index", new {project.Id});
            }

            return View(project);
        }

        [HttpGet("{id}/update")]
        public async Task<IActionResult> Update(int id)
        {
            var project = await ProjectService.GetAsync(User, id);
            return View(Mapper.Map<ProjectViewModel>(project));
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(ProjectViewModel project)
        {
            if (ModelState.IsValid)
            {
                await ProjectService.EditAsync(User, Mapper.Map<ProjectModel>(project));

                return RedirectToAction("Index", new {project.Id});
            }

            return View(project);
        }
    }
}