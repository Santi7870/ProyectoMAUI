using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ProyectoMAUI.Pages
{
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<CartItem> CartItems { get; private set; }

        private ObservableCollection<CartItem> _cartItems;

      
        
        public CartPage(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();

            // Inicializamos _cartItems con los datos pasados
            _cartItems = cartItems ?? new ObservableCollection<CartItem>();  

            // Vincular los cartItems a la interfaz
            CartListView.ItemsSource = _cartItems;
            CartItems = _cartItems;  // Asegúrate de asignar la colección correctamente
        }

        
        public CartPage()
        {
            InitializeComponent();

            // Asegúrate de que CartItems sea inicializada en este constructor también
            CartItems = new ObservableCollection<CartItem>();

            // Enlazamos la colección al BindingContext
            BindingContext = this;

            // Cargar el carrito desde el archivo cuando la página se muestra
            LoadCartAsync();
        }

        public double CartTotal => CartItems.Sum(item => item.Total); // Total general

     


        // Cargar el carrito desde el archivo JSON
        private async void LoadCartAsync()
        {
            try
            {
                // Llamamos al servicio de CartService para cargar los artículos desde el archivo
                await CartService.LoadCartAsync();

                // Agregamos los artículos cargados al ObservableCollection
                foreach (var item in CartService.GetCartItems())
                {
                    CartItems.Add(item); // Agregar cada artículo al ObservableCollection
                }

                // Actualizar el total del carrito (ya está calculado automáticamente)
                OnPropertyChanged(nameof(CartTotal));
            }
            catch (Exception ex)
            {
                
                DisplayAlert("Error", "No se pudo cargar el carrito desde el archivo: " + ex.Message, "OK");
            }
        }

        private void OnRemoveClicked(object sender, EventArgs e)
        {
            try
            {
                var button = sender as Button;
                var item = button?.CommandParameter as CartItem;

                if (item != null)
                {
                    
                    if (CartItems != null)
                    {
                        CartItems.Remove(item); // Eliminar el artículo de la colección visual
                        CartService.RemoveItem(item); // Eliminar del servicio y guardar automáticamente
                    }
                    else
                    {
                        
                        DisplayAlert("Error", "No se pudo encontrar el carrito.", "OK");
                    }

                    
                    OnPropertyChanged(nameof(CartTotal));
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si ocurre un error al eliminar el artículo
                DisplayAlert("Error", "Hubo un problema al eliminar el artículo del carrito: " + ex.Message, "OK");
            }
        }


        private void OnCheckoutClicked(object sender, EventArgs e)
        {
            try
            {
                if (CartItems == null || CartItems.Count == 0)
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
                        PurchaseDate = DateTime.Now,
                        BuyerName = UserService.CurrentUserName // Nombre del usuario actual
                    };

                    // Guardar en la base de datos
                    PurchaseService.SavePurchase(purchase);
                }

                DisplayAlert("Compra realizada", $"Compra realizada por: {UserService.CurrentUserName}\nTotal: ${CartTotal:F2}", "OK");

                // Limpiar carrito
                CartItems.Clear();
                CartService.ClearCart();

                // Asegurarse de que el total se actualice después de limpiar el carrito
                OnPropertyChanged(nameof(CartTotal));
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si ocurre un error al finalizar la compra
                DisplayAlert("Error", "Hubo un problema al realizar la compra: " + ex.Message, "OK");
            }
        }


        // Ver historial de compras
        private void OnViewHistoryClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushAsync(new PurchaseHistoryPage());
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si hay un error al intentar ver el historial
                DisplayAlert("Error", "No se pudo acceder al historial de compras: " + ex.Message, "OK");
            }
        }

        // Regresar al catálogo
        private void OnGoBackClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si hay un error al regresar
                DisplayAlert("Error", "Hubo un problema al regresar al catálogo: " + ex.Message, "OK");
            }
        }

        // Mostrar el menú lateral
        private async void OnOpenFlyoutClicked(object sender, EventArgs e)
        {
            try
            {
                // Muestra el Flyout
                Shell.Current.FlyoutIsPresented = true;
            }
            catch (Exception ex)
            {
                
                DisplayAlert("Error", "No se pudo abrir el menú: " + ex.Message, "OK");
            }
        }
    }
}






