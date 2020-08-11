﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.PL.ViewModels;

namespace ProjectManager.PL.Controllers
{
    public class SharedController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Shared/Error",
                new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}