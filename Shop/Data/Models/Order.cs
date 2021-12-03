using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(25)]
        [Required(ErrorMessage ="Длинна имени не менее 5-и символов")]

        public string name { get; set; }
        [Display(Name = "Введите фамилию")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длинна фамилии не менее 5-и символов")]

        public string surname { get; set; }
        [Display(Name = "Введите адрес")]
        [StringLength(30)]
        [Required(ErrorMessage = "Длинна адреса не менее 10-и символов")]

        public string adress { get; set; }
        [Display(Name = "Введите номер телефона")]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длинна номер не менее 10-и символов")]

        public string phone { get; set; }
        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Длинна email не менее 5-и символов")]

        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
