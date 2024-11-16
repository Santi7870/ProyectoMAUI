using Microsoft.Maui.Controls;
using ProyectoMAUI.Models;
using ProyectoMAUI.ViewModels;
using System.Collections.ObjectModel;

namespace ProyectoMAUI.Pages
{
    public partial class CatalogPage : ContentPage
    {
        public CatalogPage()
        {
            InitializeComponent();

            BindingContext = new CatalogPageViewModel();

        }

        private async void OnBuyClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var productName = (button.BindingContext as Product)?.Name;
            await DisplayAlert("Compra", $"Has añadido {productName} al carrito.", "OK");
            // Implementa lógica adicional aquí, si es necesario.
        }

        private ObservableCollection<CartItem> _cartItems = new ObservableCollection<CartItem>();

        private void OnProductBuyClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Product product)
            {
                Navigation.PushAsync(new ProductDetailPage(product, _cartItems));
            }
        }

    }
}
