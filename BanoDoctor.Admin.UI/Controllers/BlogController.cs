using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepository<BlogDetails> _IBlogRepository;

        public BlogController(IRepository<BlogDetails> blogRepo)
        {
            _IBlogRepository = blogRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogDetails model)
        {
            var response = await _IBlogRepository.AddEntity(model);
            return Json("Blog Details Addedd");
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogDetails()
        {
            var response = await _IBlogRepository.GetList(null);
            return View("~/Views/Blog/BlogPartial.cshtml", response);
        }
    }
}
