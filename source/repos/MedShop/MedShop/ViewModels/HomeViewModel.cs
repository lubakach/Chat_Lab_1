using MedShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Medicine> favMeds { get; set; }
    }
}
