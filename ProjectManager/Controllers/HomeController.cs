using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProjectManager.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return User.Identity.IsAuthenticated ? 
                RedirectToAction("Index", "Projects") : 
                RedirectToAction("Login", "Identity/Account");
        }
    }
}