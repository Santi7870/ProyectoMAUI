using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoMAUI.Models
{
    public class CartItem
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double Price { get; set; } 
        public int Quantity { get; set; } 
     
        public double Total => Price * Quantity;

    }
}

