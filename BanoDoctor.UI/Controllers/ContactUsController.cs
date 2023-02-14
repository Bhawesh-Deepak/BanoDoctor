using BanoDoctor.UI.CQRS.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IMediator _IMediator;

        public ContactUsController(IMediator mediator)
        {
            _IMediator = mediator;
        }
        public IActionResult Index()
        {
            return View("~/Views/ContactUs/ContactUs.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> CreateInquiry(CreateInquiryCommand model)
        {
            var response = await _IMediator.Send(model);

            return response ? Json("Thanks for contacting Bano Doctor ! Our Repersentative will contact you soon !") :
                Json("Something wents worng Please contact Admin Team !");
        }
    }
}
