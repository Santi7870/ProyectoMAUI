using System.Collections.ObjectModel;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.ViewModels
{
    public class CatalogPageViewModel : BaseViewModel
    {
        public ObservableCollection<Product> Hoodies { get; set; }
        public ObservableCollection<Product> Shoes { get; set; }
        public ObservableCollection<Product> Shirts { get; set; }

        public CatalogPageViewModel()
        {
            Hoodies = new ObservableCollection<Product>
            {
                new Product { Name = "Hoodie de Algodón", ImageSource = "hoodie1.jpg", Description = "Un hoodie suave y cómodo hecho de algodón puro." },
                new Product { Name = "Hoodie Casual", ImageSource = "hoodie2.jpg", Description = "Perfecto para salidas casuales y relajadas." },
                new Product { Name = "Hoodie Deportivo", ImageSource = "hoodie3.jpg", Description = "Diseñado para acompañarte durante tus entrenamientos." },
                new Product { Name = "Hoodie Elegante", ImageSource = "hoodie4.jpg", Description = "Un hoodie ideal para ocasiones semi-formales." },
                new Product { Name = "Hoodie Oversized", ImageSource = "hoodie5.jpg", Description = "Ajuste holgado para un estilo moderno y relajado." },
                new Product { Name = "Hoodie Clásico", ImageSource = "hoodie6.jpg", Description = "Un diseño clásico que nunca pasa de moda." }
            };

            Shoes = new ObservableCollection<Product>
            {
                new Product { Name = "Zapatos Clásicos", ImageSource = "shoes1.jpg", Description = "Elegancia y tradición en un diseño atemporal." },
                new Product { Name = "Zapatos Deportivos", ImageSource = "shoes2.jpg", Description = "Comodidad y soporte para actividades físicas." },
                new Product { Name = "Zapatos Casual", ImageSource = "shoes3.jpg", Description = "Versátiles para cualquier ocasión informal." },
                new Product { Name = "Zapatos de Cuero", ImageSource = "shoes4.jpg", Description = "Confeccionados con cuero de alta calidad." },
                new Product { Name = "Botines Elegantes", ImageSource = "shoes5.jpg", Description = "Estilo y sofisticación en cada paso." },
                new Product { Name = "Zapatillas Modernas", ImageSource = "shoes6.png", Description = "Diseño innovador y materiales de última generación." }
            };

            Shirts = new ObservableCollection<Product>
            {
                new Product { Name = "Camiseta Básica", ImageSource = "shirt1.jpg", Description = "El básico perfecto para cualquier guardarropa." },
                new Product { Name = "Camiseta Estampada", ImageSource = "shirt2.jpg", Description = "Destaca con diseños únicos y vibrantes." },
                new Product { Name = "Camiseta Deportiva", ImageSource = "shirt3.jpg", Description = "Ligera y transpirable para tu rutina deportiva." },
                new Product { Name = "Camiseta Oversized", ImageSource = "shirt4.jpg", Description = "Ajuste relajado para un look contemporáneo." },
                new Product { Name = "Camiseta Casual", ImageSource = "shirt5.jpg", Description = "Perfecta para salidas y días informales." },
                new Product { Name = "Camiseta Elegante", ImageSource = "shirt6.jpg", Description = "Estilo y confort en un diseño refinado." }
            };
        }
    }
}


