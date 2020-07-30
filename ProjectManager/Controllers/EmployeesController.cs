using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectManager.BLL.Services;
using ProjectManager.BLL.ViewModels;
using ProjectManager.DAL;
using ProjectManager.DAL.Entities;

namespace ProjectManager.PL.Controllers
{
    [Authorize]
    public class EmployeesController : Controller
    {
        private IEmployeeService EmployeeManager { get; }

        public EmployeesController(IEmployeeService employeeManager)
        {
            EmployeeManager = employeeManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await EmployeeManager.GetAllAsync(User));
        }

        public async Task<IActionResult> Details(int id)
        {
            var employee = await EmployeeManager.GetAsync(User, id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
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
                await EmployeeManager.CreateAsync(User, employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await EmployeeManager.GetAsync(User, id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await EmployeeManager.EditAsync(User, employee);
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
            {
                return NotFound();
            }

            return View(employee);
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
