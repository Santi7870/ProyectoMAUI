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

        private async void OnBuyClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var productName = (button.BindingContext as Product)?.Name;
            await DisplayAlert("Compra", $"Has añadido {productName} al carrito.", "OK");
            // Implementa lógica adicional aquí, si es necesario.
        }
    }
}
