using MedShop.Interfaces;
using MedShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ILogger<OrderController> _logger;
        private readonly ShopCart shopCart;
        private readonly Service service;
        public OrderController(IAllOrders allOrders, ShopCart shopCart, ILogger<OrderController> logger, Service service)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
            _logger = logger;
            this.service = service;

        }

        public IActionResult Checkout() {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else return RedirectToAction("AuthoError");
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            
                shopCart.listShopItems = shopCart.getShopItems();
                if (shopCart.listShopItems.Count == 0)
                {
                    ModelState.AddModelError("", "У вас должны быть товары!");
                }
                if (ModelState.IsValid)
                {
                    allOrders.createOrder(order);
                    service.SendEmailDefault();
                    return RedirectToAction("Complete");
                }
                return View(order);
           
        }
        
        public IActionResult AuthoError()
        {
            ViewBag.Message = "Заказы принимаются только от зарегестрированных пользователей!";
            return View();
        }
        public IActionResult Complete() {
            ViewBag.Message = "Закакз успешно обработан! Детали заказа и дополнительньная информация отправлена на вашу электронную почту!";
            return View();
        }
    }
}
