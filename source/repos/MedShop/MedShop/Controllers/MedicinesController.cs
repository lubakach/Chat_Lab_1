using MedShop.Interfaces;
using MedShop.Models;
using MedShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Controllers
{
    public class MedicinesController : Controller
    {
        private readonly ILogger<MedicinesController> _logger;
        private readonly IAllMedicines _allMedicines;
        private readonly IMedicinesCategory _allCategories;

        public MedicinesController(ILogger<MedicinesController> logger, IAllMedicines iAllMedicines, IMedicinesCategory iMedicinesCategory)
        {
            _logger = logger;
            _allMedicines = iAllMedicines;
            _allCategories = iMedicinesCategory;
        }
        [Route("Medicines/List")]
        [Route("Medicines/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Medicine> medicines = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                medicines = _allMedicines.Medicines.OrderBy(i => i.id);
            }
            else {
                if (string.Equals("medications", category, StringComparison.OrdinalIgnoreCase)) { 
                    medicines = _allMedicines.Medicines.Where(i => i.Category.categoryName.Equals("Медикаменты")).OrderBy(i => i.id);
                    currCategory = "Медикаменты";
                } else if (string.Equals("beauty", category, StringComparison.OrdinalIgnoreCase)) {
                    medicines = _allMedicines.Medicines.Where(i => i.Category.categoryName.Equals("Средства по уходу")).OrderBy(i => i.id);
                    currCategory = "Средства по уходу";
                }
            }

            var medObj = new MedicinesListViewModel
            {
                allMedicines = medicines,
                currCategory = currCategory
            };

            ViewBag.Tittle = "Страница с товарами";
            
            return View(medObj);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
