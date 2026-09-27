using Microsoft.AspNetCore.Mvc;
using lison3.Models;

namespace lison3.Controllers
{
    public class AccountController : Controller
    {
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
          
            if (string.IsNullOrWhiteSpace(model.Username) || string.IsNullOrWhiteSpace(model.Password))
            {
                ViewBag.Message = "username và password không được bỏ trống";
                ViewBag.IsSuccess = false;
                return View(model);
            }

           
            if (model.Username == "admin" && model.Password == "123")
            {
                ViewBag.Message = "Login success";
                ViewBag.IsSuccess = true;
            }
            else
            {   
                ViewBag.Message = "Login failed";
                ViewBag.IsSuccess = false;
            }

            return View(model);
        }
    }
}