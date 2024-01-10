using LiberaryBook.Data;
using LiberaryBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace LiberaryBook.Controllers
{
    public class ReadersRecordController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReadersRecordController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var records = _context.Records.Where(r => r.isActive).Select(r => new RecordViewModel()
            {
                Id = r.Id,
                LiberaryID = r.LiberaryID,
                NoOfViolations = r.NoOfViolations,
                BookId = r.BookId,
                ReturnDeadLine = r.ReturnDeadLine.ToString("dd/MM/yyyy"),
                ApproveReturnRequest = r.ApproveReturnRequest
            }).ToList();
            return View(records);
        }

        [HttpGet]
        public IActionResult addRecord()
        {
            var books = _context.Books.Where(b => b.IsActive && b.AvilableBook > 0).Select(b => new
            {
                Id = b.Id,
                Name = b.Title
            });

            ViewBag.Books = books;

            return View();
        }

        [HttpPost]
        public IActionResult removeReader(int Id)
        {
            var book = _context.Records.Where(b => b.Id == Id).FirstOrDefault();

            if (book is not null)
            {
                book.isActive = false;
                _context.SaveChanges();

                return Json(new { success = true, message = "Reader removed successfully" });
            }
            else
                return Json(new { success = false, message = "Failed to remove Reader" });
        }


        [HttpPost]
        public IActionResult addRecord(AddRecordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reader = new Record()
                {
                    LiberaryID = model.LiberaryID,
                    NoOfViolations = model.NoOfViolations,
                    BookId = model.BookId,
                    ReturnDeadLine = model.ReturnDeadLine,
                    ApproveReturnRequest = model.ApproveReturnRequest,
                    isActive = true
                };

                _context.Add(reader);
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
