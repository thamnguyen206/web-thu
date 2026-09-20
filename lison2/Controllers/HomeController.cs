using Microsoft.AspNetCore.Mvc;

namespace lisson2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to ASP.NET MVC";
        }

        public string About()
        {
            return "Nguyễn Quốc Thám";
        }

        public string Contact()
        {
            return "nguyenquoctham@example.com";
        }
    }
}