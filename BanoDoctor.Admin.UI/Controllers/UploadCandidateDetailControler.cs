using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Helpers;
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
    [DisableRequestSizeLimit]
    [RequestSizeLimit(104857600)]
    public class UploadCandidateDetailController : Controller
    {
        private readonly IHostingEnvironment _IHostingEnviroment;
        private readonly IRepository<CandidateDetailModel> _ICadidateDetailRepository;

        public UploadCandidateDetailController(IHostingEnvironment hostingEnviroment, IRepository<CandidateDetailModel> candidateRepo)
        {
            _IHostingEnviroment = hostingEnviroment;
            _ICadidateDetailRepository = candidateRepo;
        }


        public async Task<IActionResult> Index()
        {
            var response = await _ICadidateDetailRepository.GetList(null);
            return View("~/Views/CandidateDetail/CandidateDetails.cshtml", response);
        }

        public async Task<IActionResult> UploadDetail()
        {
            return await Task.Run(() => PartialView("~/Views/CandidateDetail/UploadFilePartial.cshtml"));
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile inputFile)
        {
            var uploadData = ReadExcelFile.ReadExcelData(inputFile);
            uploadData.ToList().ForEach(data =>
            {
                data.CreatedDate = DateTime.Now;
                data.IsActive = true;
            });
            var response = await _ICadidateDetailRepository.AddEnttities(uploadData.ToArray());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetCandidateDetailsById(int id)
        {
            var response = await _ICadidateDetailRepository.GetSingle(x => x.Id == id);
            return PartialView("~/Views/CandidateDetail/CandidateDetail.cshtml", response);
        }


    }
}
