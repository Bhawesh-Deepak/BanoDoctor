using BanoDoctor.Admin.UI.CQRS.Queries;
using BanoDoctor.Admin.UI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _IMedidator;

        public HomeController(IMediator mediator)
        {
            _IMedidator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetTodayInquirtyList()
        {
            var response = await _IMedidator.Send(new GetInquiryQuery() 
            { StartDate = DateTime.Now, EndDate = DateTime.Now });

            return PartialView("~/Views/Shared/Report/DailyWiserInquiryReport.cshtml", response);
        }

    }
}
