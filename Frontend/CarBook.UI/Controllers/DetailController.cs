﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.UI.Controllers
{
    [AllowAnonymous]
    public class DetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
