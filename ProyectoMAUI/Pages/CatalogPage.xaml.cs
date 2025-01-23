using Microsoft.Maui.Controls;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.Pages
{
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();
        }

        private async void OnProductBuyClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.BindingContext as Product;

            if (product != null)
            {
                // Lógica para agregar el producto al carrito o realizar la compra
                await DisplayAlert("Compra", $"Has añadido {product.Name} al carrito.", "OK");
            }
        }

        private async void OnOpenFlyoutClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}
