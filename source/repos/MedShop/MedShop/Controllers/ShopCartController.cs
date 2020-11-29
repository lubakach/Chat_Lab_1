﻿using MedShop.Interfaces;
using MedShop.Models;
using MedShop.Repository;
using MedShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Controllers
{
    public class ShopCartController : Controller
    {
        private IAllMedicines _medRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllMedicines medRep, ShopCart shopCart) {
            _medRep = medRep;
            _shopCart = shopCart;
        }

        public ViewResult Index() {
            var items = _shopCart.getShopItems();
            _shopCart.listShopItems = items;
            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };
            return View(obj);
        }

        public RedirectToActionResult addToCart(int id) {
            var item = _medRep.Medicines.FirstOrDefault(i => i.id == id);
            if (item != null) {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
