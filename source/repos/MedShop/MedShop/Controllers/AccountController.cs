using MedShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MedShop.ViewModels;
using MedShop.Models; 
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MedShop.Controllers
{
    public class AccountController : Controller
    {
        private AppDBContent db;
        private readonly Service service;
        public AccountController(AppDBContent context, Service service)
        {
            db = context;
            this.service = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CheckAuthor()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("User"))
            {
                return RedirectToAction("Info");
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("AdminPage");
            }
            else return RedirectToAction("Login");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            
            
                if (ModelState.IsValid)
                {
                    User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                    if (user != null)
                    {
                        await Authenticate(model.Email, user.Admin);
                        
                        return RedirectToAction("Index", "Home");
                        
                    }
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                return View(model);
            
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            

            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя
                    db.Users.Add(new User { Email = model.Email, Password = model.Password, Admin="User"});
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email, "User"); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

      
        private async Task Authenticate(string UserName, string Role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
               new Claim(ClaimsIdentity.DefaultNameClaimType, UserName),
               new Claim(ClaimsIdentity.DefaultRoleClaimType, Role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        
        public IActionResult Info()
        {
            ViewBag.Message = "Поздравляю! Вы в системе.";
            return View();

        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            ViewBag.Message = "Аккаунт работает в режиме 'Админ'";
            return View();

        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
       
        }
    }
}
