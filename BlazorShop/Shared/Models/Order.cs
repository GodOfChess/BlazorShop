using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Price { get; set; }
    }
}
