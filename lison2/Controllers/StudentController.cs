using Microsoft.AspNetCore.Mvc;
using lisson2.Models;

namespace lisson2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Info()
        {
            ViewBag.Name = "Nguyễn Quốc Thám";
            ViewData["Age"] = 20;

            var model = new StudentModel { Major = "CNTT" };

            return View(model);
        }
    }
}