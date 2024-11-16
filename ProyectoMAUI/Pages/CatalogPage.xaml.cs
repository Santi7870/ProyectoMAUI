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
            await DisplayAlert("Compra", $"Has a�adido {productName} al carrito.", "OK");
            // Implementa l�gica adicional aqu�, si es necesario.
        }
    }
}
