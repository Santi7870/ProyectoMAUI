using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMAUI.Models
{
    public class Purchase
    {
        public int Id { get; set; } 
        public string BuyerName { get; set; }  

        public string Name { get; set; } 
        public string Color { get; set; } 
        public string Size { get; set; } 
        public double Price { get; set; } 
        public DateTime PurchaseDate { get; set; } 
    }
}

