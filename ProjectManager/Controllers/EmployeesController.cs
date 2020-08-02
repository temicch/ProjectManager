using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Models;
using ProjectManager.BLL.Services;
using ProjectManager.ViewModels;

namespace ProjectManager.PL.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        public EmployeesController(IEmployeeService employeeManager,
            IMapper mapper)
        {
            EmployeeManager = employeeManager;
            Mapper = mapper;
        }

        private IEmployeeService EmployeeManager { get; }
        private IMapper Mapper { get; }

        public async Task<IActionResult> Index()
        {
            return View(Mapper.Map<ICollection<EmployeeViewModel>>(await EmployeeManager.GetAllAsync(User)));
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await EmployeeManager.GetAsync(User, id);
            if (employee == null) 
                return NotFound();
            return View(Mapper.Map<EmployeeViewModel>(employee));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                await EmployeeManager.CreateAsync(User, Mapper.Map<EmployeeModel>(employee));
                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await EmployeeManager.GetAsync(User, id);
            if (employee == null) 
                return NotFound();
            return View(Mapper.Map<EmployeeViewModel>(employee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await EmployeeManager.EditAsync(User, Mapper.Map<EmployeeModel>(employee));
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await EmployeeManager.GetAsync(User, id);
            if (employee == null) 
                return NotFound();

            return View(Mapper.Map<EmployeeViewModel>(employee));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            await EmployeeManager.RemoveByIdAsync(User, id);
            return RedirectToAction(nameof(Index));
        }
    }
}