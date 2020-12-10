using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.ViewModels
{
    public class EmailKeyModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public int Key { get; set; }

    }
}
