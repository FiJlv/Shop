using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shop.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
