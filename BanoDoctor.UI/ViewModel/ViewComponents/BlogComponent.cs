
using BanoDoctor.UI.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BanoDoctor.UI.ViewModel.ViewComponents
{
    public class BlogComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var models = new List<BlogModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://122.176.55.107:8089/");
                var response = await client.GetAsync("api/BlogApi/GetBlogDetails");
                if (response.IsSuccessStatusCode)
                {
                    models= JsonConvert.DeserializeObject<List<BlogModel>>(await response.Content.ReadAsStringAsync());
                }
            }
            return await Task.FromResult((IViewComponentResult)
                View("~/Views/Shared/ViewComponents/BlogView.cshtml", models.OrderByDescending(x=>x.CreatedDate).Take(4).ToList()));
        }
    }
}
