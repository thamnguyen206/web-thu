
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using lison5.Models;
using lison5.Data;

public class BooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }


    private void LoadDropdowns(int? categoryId = null, int? authorId = null)
    {
        ViewData["CategoryId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "CategoryId", "CategoryName", categoryId);
        ViewData["AuthorId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Authors, "AuthorId", "AuthorName", authorId);
    }

    // GET: BOOKS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Books.Include(b => b.Category).Include(b => b.Author).ToListAsync());
    }

    // GET: BOOKS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .Include(b => b.Category).Include(b => b.Author)
            .FirstOrDefaultAsync(m => m.BookId == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // GET: BOOKS/Create
    public IActionResult Create()
    {
        LoadDropdowns();
        return View();
    }

    // POST: BOOKS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookId,Title,ISBN,Price,Quantity,PublishYear,ImageUrl,CategoryId,AuthorId")] Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        LoadDropdowns(book.CategoryId, book.AuthorId);
        return View(book);
    }

    // GET: BOOKS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        LoadDropdowns(book.CategoryId, book.AuthorId);
        return View(book);
    }

    // POST: BOOKS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("BookId,Title,ISBN,Price,Quantity,PublishYear,ImageUrl,CategoryId,AuthorId")] Book book)
    {
        if (id != book.BookId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(book);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(book.BookId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        LoadDropdowns(book.CategoryId, book.AuthorId);
        return View(book);
    }

    // GET: BOOKS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = await _context.Books
            .Include(b => b.Category).Include(b => b.Author)
            .FirstOrDefaultAsync(m => m.BookId == id);
        if (book == null)
        {
            return NotFound();
        }

        return View(book);
    }

    // POST: BOOKS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book != null)
        {
            _context.Books.Remove(book);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookExists(int? id)
    {
        return _context.Books.Any(e => e.BookId == id);
    }
}
