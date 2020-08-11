﻿using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.PL.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Identity/Account");
        }
    }
}