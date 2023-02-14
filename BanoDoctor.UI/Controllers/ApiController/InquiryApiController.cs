using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers.ApiController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InquiryApiController : ControllerBase
    {
        private readonly IMediator _IMediator;

        public InquiryApiController(IMediator mediator)
        {
            _IMediator = mediator;
        }

        //public async Task<IActionResult> GetInquiryDetails()
        //{
        //    var response= await _IMediator.Send(new Get)
        //}
    }
}
