using Microsoft.AspNetCore.Mvc;
using System;

namespace LiberaryBook.Controllers
{
    public class LiberaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
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


  
