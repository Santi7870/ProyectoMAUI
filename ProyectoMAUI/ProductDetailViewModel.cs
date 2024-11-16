using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace ProyectoMAUI.Models
{
    public class ProductDetailViewModel
    {
        public Product Product { get; }
        public ObservableCollection<string> AvailableSizes { get; } = new ObservableCollection<string> { "S", "M", "L", "XL" };
        public ObservableCollection<string> AvailableColors { get; } = new ObservableCollection<string> { "Rojo", "Azul", "Negro", "Blanco" };

        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }

        public ProductDetailViewModel(Product product)
        {
            Product = product;
        }
    }
}
