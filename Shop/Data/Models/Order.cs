﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public int Id { get; set; }

        [Display(Name = "Enter name")]
        [StringLength(30)]
        [Required(ErrorMessage = "The name must be at least 5 characters long")]
        public string Name { get; set; }

        [Display(Name = "Enter surname")]
        [StringLength(30)]
        [Required(ErrorMessage = "The surname must be at least 5 characters long")]

        public string Surname { get; set; }

        [Display(Name = "Enter address")]
        [StringLength(30)]
        [Required(ErrorMessage = "The address must be at least 10 characters long")]
        public string Address { get; set; }

        [Display(Name = "Enter email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "The email must be at least 5 characters long")]
        public string Email { get; set; }

        [Display(Name = "Enter phone number")]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The phone number must be at least 10 characters long")]
        public string Phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
