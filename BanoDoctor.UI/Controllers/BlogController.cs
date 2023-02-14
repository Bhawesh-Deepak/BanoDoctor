using BanoDoctor.UI.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BanoDoctor.UI.Controllers
{
    public class BlogController : Controller
    {
        public async Task<IActionResult> Index(int id)
        {
            var model = new BlogModel();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://122.176.55.107:8089/");
                var response=await client.GetAsync("api/BlogApi/GetBlogDetailById?id="+ id);

                if (response.IsSuccessStatusCode)
                {
                    model = JsonConvert.DeserializeObject<BlogModel>(await response.Content.ReadAsStringAsync());
                }
            }
            return View("~/views/Blog/Index.cshtml", model);
        }
    }
}
