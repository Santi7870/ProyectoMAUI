using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Models
{
    public class Purchase
    {
        public int Id { get; set; } // ID único para la compra
        public string BuyerName { get; set; }  // Nombre del comprador

        public string Name { get; set; } // Nombre del producto
        public string Color { get; set; } // Color seleccionado
        public string Size { get; set; } // Talla seleccionada
        public double Price { get; set; } // Precio
        public DateTime PurchaseDate { get; set; } // Fecha de la compra
    }
}

