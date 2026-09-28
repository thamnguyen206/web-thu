using Microsoft.AspNetCore.Mvc;
using YourProjectName.Models;

namespace YourProjectName.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

      
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
        
            var products = _context.Product.ToList();

            return View(products);
        }
    }
}