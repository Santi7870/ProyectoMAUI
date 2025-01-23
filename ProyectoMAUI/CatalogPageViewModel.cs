using System.Collections.ObjectModel;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.ViewModels
{
    public class CatalogPageViewModel
    {
        public ObservableCollection<Product> Hoodies { get; set; }
        public ObservableCollection<Product> Shoes { get; set; }
        public ObservableCollection<Product> Shirts { get; set; }

        public CatalogPageViewModel()
        {
            Hoodies = new ObservableCollection<Product>
            {
                new Product { Name = "Hoodie de Algodón", ImageSource = "hoodie1.jpg" },
                new Product { Name = "Hoodie Casual", ImageSource = "hoodie2.jpg" },
                new Product { Name = "Hoodie Deportivo", ImageSource = "hoodie3.jpg" },
                new Product { Name = "Hoodie Elegante", ImageSource = "hoodie4.jpg" },
                new Product { Name = "Hoodie Oversized", ImageSource = "hoodie5.jpg" },
                new Product { Name = "Hoodie Clásico", ImageSource = "hoodie6.jpg" }
            };

            Shoes = new ObservableCollection<Product>
            {
                new Product { Name = "Zapatos Clásicos", ImageSource = "shoes1.jpg" },
                new Product { Name = "Zapatos Deportivos", ImageSource = "shoes2.jpg" },
                new Product { Name = "Zapatos Casual", ImageSource = "shoes3.jpg" },
                new Product { Name = "Zapatos de Cuero", ImageSource = "shoes4.jpg" },
                new Product { Name = "Botines Elegantes", ImageSource = "shoes5.jpg" },
                new Product { Name = "Zapatillas Modernas", ImageSource = "shoes6.jpg" }
            };

            Shirts = new ObservableCollection<Product>
            {
                new Product { Name = "Camiseta Básica", ImageSource = "shirt1.jpg" },
                new Product { Name = "Camiseta Estampada", ImageSource = "shirt2.jpg" },
                new Product { Name = "Camiseta Deportiva", ImageSource = "shirt3.jpg" },
                new Product { Name = "Camiseta Oversized", ImageSource = "shirt4.jpg" },
                new Product { Name = "Camiseta Casual", ImageSource = "shirt5.jpg" },
                new Product { Name = "Camiseta Elegante", ImageSource = "shirt6.jpg" }
            };
        }
    }
}
