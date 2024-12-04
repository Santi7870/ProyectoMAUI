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

      
        // Aseg�rate de que CartPage tenga un constructor que acepte un ObservableCollection<CartItem>
        public CartPage(ObservableCollection<CartItem> cartItems)
        {
            InitializeComponent();

            // Inicializamos _cartItems con los datos pasados
            _cartItems = cartItems ?? new ObservableCollection<CartItem>();  // Aseg�rate de que _cartItems no sea null

            // Vincular los cartItems a la interfaz
            CartListView.ItemsSource = _cartItems;
            CartItems = _cartItems;  // Aseg�rate de asignar la colecci�n correctamente
        }

        // Constructor vac�o para la p�gina del carrito (cuando no se pasa un ObservableCollection<CartItem>)
        public CartPage()
        {
            InitializeComponent();

            // Aseg�rate de que CartItems sea inicializada en este constructor tambi�n
            CartItems = new ObservableCollection<CartItem>();

            // Enlazamos la colecci�n al BindingContext
            BindingContext = this;

            // Cargar el carrito desde el archivo cuando la p�gina se muestra
            LoadCartAsync();
        }

        public double CartTotal => CartItems.Sum(item => item.Total); // Total general

        // Constructor de la p�gina del carrito


        // Cargar el carrito desde el archivo JSON
        private async void LoadCartAsync()
        {
            try
            {
                // Llamamos al servicio de CartService para cargar los art�culos desde el archivo
                await CartService.LoadCartAsync();

                // Agregamos los art�culos cargados al ObservableCollection
                foreach (var item in CartService.GetCartItems())
                {
                    CartItems.Add(item); // Agregar cada art�culo al ObservableCollection
                }

                // Actualizar el total del carrito (ya est� calculado autom�ticamente)
                OnPropertyChanged(nameof(CartTotal));
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si hay alg�n error al cargar el carrito
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
                    // Verificar que CartItems no sea null antes de realizar la eliminaci�n
                    if (CartItems != null)
                    {
                        CartItems.Remove(item); // Eliminar el art�culo de la colecci�n visual
                        CartService.RemoveItem(item); // Eliminar del servicio y guardar autom�ticamente
                    }
                    else
                    {
                        // Mostrar un mensaje si CartItems es null
                        DisplayAlert("Error", "No se pudo encontrar el carrito.", "OK");
                    }

                    // Asegurarse de que el total se actualice correctamente despu�s de eliminar un art�culo
                    OnPropertyChanged(nameof(CartTotal));
                }
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si ocurre un error al eliminar el art�culo
                DisplayAlert("Error", "Hubo un problema al eliminar el art�culo del carrito: " + ex.Message, "OK");
            }
        }


        private void OnCheckoutClicked(object sender, EventArgs e)
        {
            try
            {
                if (CartItems == null || CartItems.Count == 0)
                {
                    DisplayAlert("Carrito vac�o", "No hay productos en el carrito para comprar.", "OK");
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

                // Asegurarse de que el total se actualice despu�s de limpiar el carrito
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

        // Regresar al cat�logo
        private void OnGoBackClicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si hay un error al regresar
                DisplayAlert("Error", "Hubo un problema al regresar al cat�logo: " + ex.Message, "OK");
            }
        }

        // Mostrar el men� lateral
        private async void OnOpenFlyoutClicked(object sender, EventArgs e)
        {
            try
            {
                // Muestra el Flyout
                Shell.Current.FlyoutIsPresented = true;
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje si hay un error al abrir el Flyout
                DisplayAlert("Error", "No se pudo abrir el men�: " + ex.Message, "OK");
            }
        }
    }
}






