using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}
