using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.DAL.Entities;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Employee> userManager;

        public HomeController(UserManager<Employee> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return User.Identity.IsAuthenticated ? 
                RedirectToAction("Index", "Tasks") : 
                RedirectToAction("Login", "Identity/Account");
        }
    }
}