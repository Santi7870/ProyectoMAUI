using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI
{
    // Modelo Pedido en la aplicación MAUI
    public class Pedido
    {
        public string Name { get; set; }        // Nombre del producto o pedido
        public string Description { get; set; } // Descripción del producto o pedido

        // Datos del usuario que hizo el pedido
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
    }

}
