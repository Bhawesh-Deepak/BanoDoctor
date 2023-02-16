using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class UserDetailController : Controller
    {
        private readonly IRepository<UserModel> _IUserModelRepository;

        public UserDetailController(IRepository<UserModel> userRepository)
        {
            _IUserModelRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _IUserModelRepository.GetList(x => x.IsActive);
            return View("~/Views/UserManagement/UserDetail.cshtml", response);
        }

        public async Task<IActionResult> CreateUser(int id)
        {
            var response = await _IUserModelRepository.GetSingle(x => x.Id == id);
            return PartialView("~/Views/UserManagement/CreateUser.cshtml", response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserPost(UserModel model)
        {
            model.CreatedDate = DateTime.Now;
            model.IsActive = true;
            if (model.Id == 0)
            {
                var response = await _IUserModelRepository.AddEntity(model);
                return Json(response == true ? "User Created successfully !" :
                     "Something wents wrong Please contact admin !");
            }

            var updateResponse = await _IUserModelRepository.Update(model);
            return Json(updateResponse == true ? "User Updated successfully !" :
                 "Something wents wrong Please contact admin !");

        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteModel = await _IUserModelRepository.GetSingle(x => x.Id == id);
            deleteModel.IsActive = false;
            var deleteResponse = await _IUserModelRepository.Update(deleteModel);

            return Json(deleteResponse == true ? "User deleted successfully !" :
                    "Something wents wrong Please contact admin !");
        }
    }
}
