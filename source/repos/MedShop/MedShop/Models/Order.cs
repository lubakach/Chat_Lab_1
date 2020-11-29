using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedShop.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name="Введите имя")]
        [StringLength(23)]
        [Required(ErrorMessage ="Длина имени не менее 5 символов")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(33)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Длина адреса не менее 10 символов")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера не менее 10 символов")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [StringLength(15)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина email не менее 15 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }


    }
}
