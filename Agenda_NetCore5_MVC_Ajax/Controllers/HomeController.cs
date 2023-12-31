﻿using Agenda_NetCore5_MVC_Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agenda_NetCore5_MVC_Ajax.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
