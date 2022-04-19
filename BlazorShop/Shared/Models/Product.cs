using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public string Img { get; set; } = "https://via.placeholder.com/300x300";
        public int Price { get; set; }
    }
}
