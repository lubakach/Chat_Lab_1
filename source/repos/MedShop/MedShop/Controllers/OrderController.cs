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

            shopCart.listShopItems = shopCart.getShopItems();

            
            if (shopCart.listShopItems.Count == 0) {
                return RedirectToAction("Error");
            }
            if (shopCart.listShopItems.Count == 0 & User.Identity.IsAuthenticated!)
            {
                return RedirectToAction("AuthoError");
            }
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("AuthoError");
            }
            else return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.getShopItems();
            if (shopCart.listShopItems.Count == 0)
            {
                return RedirectToAction("Error");
            }
            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                service.SendEmailDefault(order.email, order.name, order.surname);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Error()
        {
            ViewBag.Message = "Упс! Вы не добавили товары в корзину!";
            return View();
        }
        
        public IActionResult AuthoError()
        {
            ViewBag.Message = "Заказы принимаются только от зарегистрированных пользователей!";
            return View();
        }
        public IActionResult Complete() {
            ViewBag.Message = "Заказ успешно обработан! Детали заказа и дополнительньная информация отправлена на вашу электронную почту!";
            return View();
        }
    }
}
