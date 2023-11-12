using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System;

namespace Shop.ViewModels
{
    public class OrderViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [StringLength(30)]
        [Required(ErrorMessage = "The name must be at least 5 characters long")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [StringLength(30)]
        [Required(ErrorMessage = "The surname must be at least 5 characters long")]
        public string Surname { get; set; }

        [Display(Name = "Address")]
        [StringLength(30)]
        [Required(ErrorMessage = "The address must be at least 10 characters long")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "The email must be at least 5 characters long")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        [StringLength(30)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "The phone number must be at least 10 characters long")]
        public string Phone { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
    }
}
