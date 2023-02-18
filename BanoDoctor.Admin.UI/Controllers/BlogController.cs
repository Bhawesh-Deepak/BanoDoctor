using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IRepository<BlogDetails> _IBlogRepository;
        private readonly IHostingEnvironment _IHostingEnviroment;
        public BlogController(IRepository<BlogDetails> blogRepo, IHostingEnvironment hostingEnviroment)
        {
            _IBlogRepository = blogRepo;
            _IHostingEnviroment = hostingEnviroment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogDetails model)
        {
            if (model.UploadImage != null)
            {
                var fileName = Path.GetFileName(model.UploadImage.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                string completePath = string.Empty;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.UploadImage.CopyToAsync(fileStream);
                    completePath = fileName;
                }
                model.ImagePath = completePath;
            }
            var response = await _IBlogRepository.AddEntity(model);
            if (response)
            {
                return Json("Blog Details Addedd");
            }
            else
            {
                return Json("Something wents wrong, Please contact admin !");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetBlogDetails()
        {
            var response = await _IBlogRepository.GetList(null);
            return View("~/Views/Blog/BlogPartial.cshtml", response);
        }
    }
}
