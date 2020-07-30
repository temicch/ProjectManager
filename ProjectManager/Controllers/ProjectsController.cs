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
            IProjectService projectManager, 
            IMapper mapper,
            ITaskService taskService
            )
        {
            ProjectManager = projectManager ?? throw new ArgumentNullException(nameof(projectManager));
            Mapper = mapper;
            TaskService = taskService;
        }

        private IProjectService ProjectManager { get; }
        private IMapper Mapper { get; }
        private ITaskService TaskService { get; }

        [HttpGet("index")]
        public async Task<IActionResult> Index()
        {

            //var id = await ProjectManager.CreateAsync(User, new ProjectViewModel()
            //{
            //    CustomerCompany = "Sibers",
            //    EndDate = DateTime.Now,
            //    StartDate = DateTime.Now,
            //    PerformerCompany = "Fin Pack",
            //    Priority = 300,
            //    Title = "Make DB"
            //});


            //var entity = Mapper.Map<ProjectViewModel>(new Project()
            //{
            //    Title = "Money Pen",
            //    StartDate = DateTime.Now.AddYears(-2),
            //    EndDate = DateTime.Now.AddYears(-1),
            //    PerformerCompany = "Sibers",
            //    CustomerCompany = "Australian Company",
            //    Priority = 4,
            //    ManagerId = 1,
            //});
            //await ProjectManager.CreateAsync(User, entity);

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

            //await ProjectManager.CreateAsync(User,
            //Mapper.Map<ProjectViewModel>(new Project()
            //{
            //    Title = "Radio Tuner",
            //    StartDate = DateTime.Now.AddYears(-3),
            //    EndDate = DateTime.Now.AddYears(-2),
            //    PerformerCompany = "Sibers",
            //    CustomerCompany = "PS Audio",
            //    Priority = 10,
            //    ManagerId = 3,
            //}));

            //await ProjectManager.CreateAsync(User,
            //Mapper.Map<ProjectViewModel>(new Project()
            //{
            //    Title = "Gas Wizard",
            //    StartDate = DateTime.Now.AddYears(-3),
            //    EndDate = DateTime.Now.AddYears(-2),
            //    PerformerCompany = "Sibers",
            //    CustomerCompany = "Some company",
            //    Priority = 124,
            //    ManagerId = 4,
            //}));

            //await ProjectManager.CreateAsync(User,
            //Mapper.Map<ProjectViewModel>(new Project()
            //{
            //    Title = "TRI-LOGG",
            //    StartDate = DateTime.Now.AddYears(-3),
            //    EndDate = DateTime.Now.AddYears(-1),
            //    PerformerCompany = "Sibers",
            //    CustomerCompany = "Another Company",
            //    Priority = 141,
            //    ManagerId = 5,
            //}));

            //await TaskService.CreateAsync(User,
            //Mapper.Map<ProjectTaskViewModel>(new ProjectTask()
            //{
            //    AuthorId = 4,
            //    PerformerId = 3,
            //    Priority = 144,
            //    Status = DAL.Entities.TaskStatus.Done,
            //    ProjectId = 8,
            //    Title = "Исследование",
            //    Comment = "Оценить потребности"
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