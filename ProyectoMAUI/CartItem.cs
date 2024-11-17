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
        public double Price { get; set; } // Precio del producto
        public int Quantity { get; set; } // Cantidad en el carrito

        // Total por producto (precio * cantidad)
        public double Total => Price * Quantity;

    }
}

