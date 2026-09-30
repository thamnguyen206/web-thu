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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync(); 

                return RedirectToAction(nameof(Index)); 
            }

           
            var products = _context.Products.ToList();
            return View("Index", products);
        }
    }
}