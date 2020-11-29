using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Medicine medicine { get; set; }
        public int price { get; set; }
        public string ShopCartId { get; set; }
    }
}
