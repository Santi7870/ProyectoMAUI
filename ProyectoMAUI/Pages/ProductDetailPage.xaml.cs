using Microsoft.Maui.Controls;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(Product product)
        {
            InitializeComponent();
            BindingContext = new ProductDetailViewModel(product);
        }

        private async void OnBuyClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Compra", $"Has comprado: {((ProductDetailViewModel)BindingContext).Product.Name}", "OK");
        }

        private async void OnAddToCartClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Carrito", $"Has agregado: {((ProductDetailViewModel)BindingContext).Product.Name} al carrito", "OK");
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
