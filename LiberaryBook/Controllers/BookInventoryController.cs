using LiberaryBook.Data;
using LiberaryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryBook.Controllers
{
    public class BookInventoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookInventoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index( string book= null)
        {
            var books = _context.Books.Where(b => b.IsActive && (book == null || book == "null" || book.Contains(b.Title) || b.Title.Contains(book)))
                                      .Select(b => new BookViewModel()
                                      {
                                          Id = b.Id,
                                          Title = b.Title,
                                          Author = b.Author,
                                          BorrowedBook = b.BorrowedBook,
                                          AvilableBook = b.AvilableBook,
                                          TotalInvetory = b.TotalInvetory
                                      }).ToList();

            return View(books);
        }

        [HttpPost]
        public IActionResult removeBook(int Id)
        {
            var book = _context.Books.Where(b => b.Id == Id).FirstOrDefault();

            if (book is not null)
            {
                book.IsActive = false;
                _context.SaveChanges();

                return Json(new { success = true, message = "Book removed successfully" });
            }
            else
                return Json(new { success = false, message = "Failed to remove book" });
        }

        [HttpGet]
        public IActionResult addBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addBook(AddBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = new Book()
                {
                    Title = model.Title,
                    Author = model.Author,
                    TotalInvetory = model.TotalInvetory,
                    AvilableBook = model.AvilableBook,
                    BorrowedBook = model.BorrowedBook,
                    IsActive = true
                };

                _context.Add(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            string redirectUrl = Url.Action("Index", "Home");

            // Return the redirect URL as JSON
            return Json(new { url = redirectUrl });
        }
       
    }
}
