using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/AboutUs/AboutUs.cshtml");
        }
    }
}
