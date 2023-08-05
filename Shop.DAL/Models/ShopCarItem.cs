using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCarItem
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public uint Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
