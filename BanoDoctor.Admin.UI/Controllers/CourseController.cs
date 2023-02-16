using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class CourseController : Controller
    {
        private readonly IRepository<CourseDetail> _ICourseDetailRepository;

        public CourseController(IRepository<CourseDetail> courseDetailRepo)
        {
            _ICourseDetailRepository = courseDetailRepo;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _ICourseDetailRepository.GetList(x => x.IsActive == true);
            return View("~/Views/Course/Index.cshtml", response);
        }

        public async Task<IActionResult> CreateCourse(int id)
        {
            var response = await _ICourseDetailRepository.GetSingle(x => x.Id == id);
            return await Task.Run(() => PartialView("~/views/Course/CreateCoursePartial.cshtml", response));
        }
        [HttpPost]
        public async Task<IActionResult> PostCourse(CourseDetail model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.IsActive = true;
                if (model.Id == 0)
                {
                    var response = await _ICourseDetailRepository.AddEntity(model);
                    return response ? Json("Course has been created successfully !")
                        : Json("There is some issue, Please contact admin Team");
                }

                var updateResponse = await _ICourseDetailRepository.Update(model);
                return updateResponse ? Json("Course has been updated successfully !")
                    : Json("There is some issue, Please contact admin Team");

            }
            catch (Exception ex)
            {
                return Json("Something wents wrong, Please contact admin !");
            }

        }

        public async Task<IActionResult> DeleteCourse(int id)
        {
            var model = await _ICourseDetailRepository.GetSingle(x => x.Id == id);
            model.IsActive = false;
            var deleteResponse = await _ICourseDetailRepository.Update(model);

            return deleteResponse ? Json("Course has been deleted successfully !")
                    : Json("There is some issue, Please contact admin Team");
        }

    }
}
