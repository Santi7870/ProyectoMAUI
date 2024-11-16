using ProyectoMAUI.Models;
using System.Collections.ObjectModel;

namespace ProyectoMAUI.Pages
{
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<CartItem> CartItems { get; set; }

        public CartPage(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();
            CartItems = cartItems;
            BindingContext = this;  // Establecemos el BindingContext de la p�gina
        }

        // M�todo para eliminar un item del carrito
        private void OnRemoveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var itemToRemove = button?.CommandParameter as CartItem;
            if (itemToRemove != null)
            {
                CartItems.Remove(itemToRemove);  // Eliminar el item
            }
        }

        // Acci�n para volver a la p�gina anterior
        private void OnGoBackClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}




