using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
using System.Collections.ObjectModel;

namespace ProyectoMAUI.Pages
{
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<CartItem> CartItems { get; private set; }
        public double CartTotal => CartItems.Sum(item => item.Total); // Total general

        public CartPage(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();

            // Usar la colección pasada como parámetro
            CartItems = cartItems;

            // Enlazar la colección a la interfaz
            BindingContext = this;
        }


        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button?.CommandParameter as CartItem;

            if (item != null)
            {
                CartItems.Remove(item); // Actualizar la colección vinculada
                OnPropertyChanged(nameof(CartTotal)); // Notificar el cambio del total
            }
        }

        private void OnCheckoutClicked(object sender, EventArgs e)
        {
            if (CartItems.Count == 0)
            {
                DisplayAlert("Carrito vacío", "No hay productos en el carrito para comprar.", "OK");
                return;
            }

            foreach (var item in CartItems)
            {
                var purchase = new Purchase
                {
                    Name = item.Name,
                    Color = item.Color,
                    Size = item.Size,
                    Price = item.Price,
                    PurchaseDate = DateTime.Now
                };

                // Guardar en la base de datos
                PurchaseService.SavePurchase(purchase);
            }

            DisplayAlert("Compra realizada", $"Se ha completado la compra. Total: ${CartTotal:F2}", "OK");

            // Limpiar carrito
            CartItems.Clear();
            CartService.ClearCart();
            OnPropertyChanged(nameof(CartTotal));
        }

        private void OnViewHistoryClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PurchaseHistoryPage());
        }



        private void OnGoBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}




