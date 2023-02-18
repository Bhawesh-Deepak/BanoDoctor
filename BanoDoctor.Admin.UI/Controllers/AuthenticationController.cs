using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IRepository<UserModel> _IAuthenticateRepository;

        public AuthenticationController(IRepository<UserModel> userRepository)
        {
            _IAuthenticateRepository = userRepository;

        }
        public IActionResult Index(string message="")
        {
           
            return View("~/Views/Authentication/Login.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Authenticate(UserModel model, string returnUrl = null)
        {
            var responseModel =await  _IAuthenticateRepository.GetSingle(x => x.UserName.Trim().ToLower()
                             == model.UserName.Trim().ToLower() && x.Password.Trim().ToLower() == model.Password.Trim().ToLower());

            if (responseModel != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else {
                return RedirectToAction("Index", "Authentication");
            }

           
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            //HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Authentication");
        }
    }
}
