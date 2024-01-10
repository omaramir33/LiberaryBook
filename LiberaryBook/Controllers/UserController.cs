using LiberaryBook.Data;
using LiberaryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryBook.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context; 

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult books(string book = null)
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

        [HttpGet]
        public IActionResult borrowBook()
        {
            var books = _context.Books.Where(b => b.IsActive && b.AvilableBook > 0).Select(b => new
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();

            ViewBag.books = books;

            return View();
        }

        [HttpPost]
        public IActionResult borrowBook(borrowBookViewModel model)
        {
            if (ModelState.IsValid)
            {
                var book = _context.Books.Where(b => b.Id == model.Id).FirstOrDefault();

                if(book is not null)
                {
                    book.AvilableBook -= 1;

                    _context.SaveChanges();
                }
                return RedirectToAction("books");

            };

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
