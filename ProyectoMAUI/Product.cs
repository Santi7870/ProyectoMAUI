using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Models
{
    public class Product
    {
        public string Name { get; set; }
        public string ImageSource { get; set; }
        public List<string> Sizes { get; set; } // Propiedad para tallas
        public List<string> Colors { get; set; } // Propiedad para colores
        public string Description { get; set; }
        public double Price { get; set; } 

    }
}

