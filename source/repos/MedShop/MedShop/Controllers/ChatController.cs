using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Controllers
{
    public class ChatController : Controller
    {

        public IActionResult Questions()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Error");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("User")) 
            {
                return RedirectToAction("Convo");
            }
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                return RedirectToAction("Convo");
            }
            else return View();

        }

        public IActionResult Convo()
        {
            ViewBag.Message = "Место где вы можете задать вапросы нашему оператору!";
            return View();
        }

        public IActionResult Error()
        {
            ViewBag.Message = "Упс! Вы забыли авторизоваться";
            return View();
        }
    }
}
