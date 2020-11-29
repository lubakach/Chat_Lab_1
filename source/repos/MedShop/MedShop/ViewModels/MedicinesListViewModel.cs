using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.ViewModels
{
    public class MedicinesListViewModel
    {
        public IEnumerable<Medicine> allMedicines { get; set; }
        public string currCategory { get; set; }
    }
}
