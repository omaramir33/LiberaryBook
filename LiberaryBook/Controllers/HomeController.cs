using LiberaryBook.Data;
using LiberaryBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LiberaryBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginViewModel login)
        {
            var validation = CheckIdAndPass(login);
            if (ModelState.IsValid)
            {
                if (validation)
                {
                    if (login.Id < 2000)
                    return Json(new { redirectTo = Url.Action("Index", "User") });


                    else if (login.Id > 2000)
                        return Json(new { redirectTo = Url.Action("Index", "Liberary") });
                }
            }

            return View("Login");

        }

        [HttpGet]
        public bool CheckIdAndPass(LoginViewModel login)
        {
            var isIdFound = _context.Users.Where(u => u.IDNumber == login.Id).FirstOrDefault();
            var ispassFound = _context.Users.Where(u => u.Password == login.Password).FirstOrDefault();

            if (isIdFound is not null && ispassFound is not null)

                return true;

            else
                return false;
        }

    }
}
