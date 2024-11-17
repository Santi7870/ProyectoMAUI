using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
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
            if (SizePicker.SelectedItem == null || ColorPicker.SelectedItem == null)
            {
                DisplayAlert("Error", "Por favor selecciona talla y color antes de agregar al carrito.", "OK");
                return;
            }

            // Crear un nuevo objeto CartItem con los datos seleccionados
            var cartItem = new CartItem
            {
                Name = ProductNameLabel.Text, // Nombre del producto
                Color = ColorPicker.SelectedItem.ToString(), // Color seleccionado
                Size = SizePicker.SelectedItem.ToString(), // Talla seleccionada
                Price = double.Parse(ProductPriceLabel.Text.Trim('$')), // Precio
                Quantity = 1 // Cantidad predeterminada
            };

            // Agregar el producto al carrito
            _cartItems.Add(cartItem);

            DisplayAlert("Éxito", "Producto agregado al carrito.", "OK");
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


