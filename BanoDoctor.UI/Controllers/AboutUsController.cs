using BanoDoctor.UI.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly IMediator _ImediatR;

        public AboutUsController(IMediator mediator)
        {
            _ImediatR = mediator;
        }
        public IActionResult Index()
        {
            return View("~/Views/AboutUs/AboutUs.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateInquiry(CreateInquiryCommand model)
        {
            var response= await _ImediatR.Send(model);
            return Json(response);
        }
    }
}
