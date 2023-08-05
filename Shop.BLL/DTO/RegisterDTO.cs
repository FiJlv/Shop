using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class RegisterDTO
    {
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

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
