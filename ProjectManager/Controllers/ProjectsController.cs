using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL.Entities;

namespace ProjectManager.Controllers
{
    [Authorize]
    [Route("projects")]
    public class ProjectsController : Controller
    {
        public ProjectsController(
            IProjectService projectManager
            )
        {
            ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
        }

        private IProjectService ProjectManager { get; }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {
            //await ProjectManager.CreateAsync(User,
            //Mapper.Map<ProjectViewModel>(new Project()
            //{
            //    Title = "Voice Base",
            //    StartDate = DateTime.Now.AddYears(-7),
            //    EndDate = DateTime.Now,
            //    PerformerCompany = "Sibers",
            //    CustomerCompany = "Voice Analytic Company",
            //    Priority = 12,
            //    ManagerId = 2,
            //}));

            var projectsViewModels = await ProjectManager.GetAllAsync(User);
            return View(projectsViewModels);
        }

        [HttpGet("{taskId}")]
        public IActionResult Read(int projectId)
        {
            var readData = ProjectManager.GetAsync(User, projectId).Result;
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
            var data = await ProjectManager.GetAsync(User, id);
            return View(data);
        }

        [HttpPost("{id}/update")]
        public async Task<IActionResult> Update(ProjectViewModel writeData)
        {
            if (ModelState.IsValid)
            {
                await ProjectManager.EditAsync(User, writeData);

                return RedirectToAction("Index", new {writeData.Id});
            }
            else
            {
                return View(writeData);
            }
        }
    }
}