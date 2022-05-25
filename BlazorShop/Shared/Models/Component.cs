using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Models
{
    public class Component
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Maker { get; set; }
        public string ItemPrice { get; set; }
        public string Amount { get; set; }
    }
}
