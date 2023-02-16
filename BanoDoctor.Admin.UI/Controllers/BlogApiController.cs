using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogApiController : ControllerBase
    {
        private readonly IRepository<BlogDetails> _IBlogRepository;
       
        public BlogApiController(IRepository<BlogDetails> blogRepo)
        {
            _IBlogRepository = blogRepo;
         
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetBlogDetails()
        {
            var response = await _IBlogRepository.GetList(x => x.Ispublished);
            return Ok(response);
        }

        [HttpGet]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> GetBlogDetailById(int id)
        {
            var response = await _IBlogRepository.GetSingle(x => x.Id==id);
            return Ok(response);
        }
    }
}
