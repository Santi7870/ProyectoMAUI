using ProyectoMAUI.Models;
using System.Collections.ObjectModel;

namespace ProyectoMAUI.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        private ObservableCollection<CartItem> _cartItems;

        public ProductDetailPage(Product product, ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();

            // Guardamos el cartItems
            _cartItems = cartItems;

            // Establecer los detalles del producto en la interfaz
            ProductNameLabel.Text = product.Name;
            ProductDescriptionLabel.Text = product.Description;

            if (product.Price == 0)
            {
                product.Price = new Random().Next(10, 100);  // Precio aleatorio entre 10 y 100
            }

            ProductPriceLabel.Text = $"${product.Price:F2}";
        }

        private void OnAddToCartClicked(object sender, EventArgs e)
        {
            // Agregar el producto al carrito
            var newItem = new CartItem
            {
                Name = ProductNameLabel.Text,
                Size = SizePicker.SelectedItem?.ToString(),
                Color = ColorPicker.SelectedItem?.ToString()
            };

            if (!string.IsNullOrEmpty(newItem.Size) && !string.IsNullOrEmpty(newItem.Color))
            {
                _cartItems.Add(newItem);
                DisplayAlert("Éxito", "Producto agregado al carrito.", "OK");
            }
            else
            {
                DisplayAlert("Error", "Seleccione talla y color antes de agregar al carrito.", "OK");
            }
        }

        private void OnGoToCartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage(_cartItems));
        }

        private void OnGoBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void OnBuyClicked(object sender, EventArgs e)
        {
            // Funcionalidad para realizar la compra
            DisplayAlert("Compra", "La compra ha sido realizada con éxito.", "OK");


        }

        // Evento para manejar la selección de tamaño
        private void OnSizeSelected(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker != null)
            {
                SelectedSizeLabel.Text = $"Talla seleccionada: {picker.SelectedItem}";
            }
        }

        // Evento para manejar la selección de color
        private void OnColorSelected(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker != null)
            {
                SelectedColorLabel.Text = $"Color seleccionado: {picker.SelectedItem}";
            }
        }
    }
}


