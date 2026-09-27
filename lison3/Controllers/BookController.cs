using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using lison3.Models;

namespace lison3.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Name = "Clean Code", Price = 20 },
            new Book { Id = 2, Name = "ASP.NET MVC", Price = 15 },
            new Book { Id = 3, Name = "Design Pattern", Price = 25 }
        };

       
        public IActionResult Index()
        {
            return View(_books);
        }

       
        public IActionResult Detail(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

    
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Create(Book book)
        {
          
            if (ModelState.IsValid)
            {
                book.Id = _books.Any() ? _books.Max(b => b.Id) + 1 : 1;
                _books.Add(book);

                TempData["SuccessMessage"] = "Thêm sách thành công!";
                return RedirectToAction("Index");
            }

           
            return View(book);
        }
    }
}