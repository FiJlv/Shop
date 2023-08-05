using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
