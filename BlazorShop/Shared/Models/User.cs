using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShop.Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public bool IsAdmin { get; set; }
    }
}
