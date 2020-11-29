using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int MedicineID { get; set; }
        public uint price { get; set; }
        public virtual Medicine medicine { get; set; }
        public virtual Order order { get; set; }
    }
}
