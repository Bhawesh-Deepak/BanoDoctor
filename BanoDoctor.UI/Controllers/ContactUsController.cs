using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/ContactUs/ContactUs.cshtml");
        }
    }
}
