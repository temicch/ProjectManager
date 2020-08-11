using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return User.Identity.IsAuthenticated
                ? RedirectToAction("Index", "Projects")
                : RedirectToAction("Login", "Account");
        }
    }
}