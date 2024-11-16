using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
using Microsoft.Maui.Controls;

namespace ProyectoMAUI.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Verifica si los controles de entrada están correctamente configurados
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            // Validar usuario
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor ingrese todos los campos.", "OK");
                return;
            }

            // Buscar usuario en la base de datos
            var user = await App.Database.GetUserAsync(username);

            if (user != null && user.Clave == password)
            {
                // Iniciar sesión exitoso, navegar al catálogo
                await Navigation.PushAsync(new CatalogPage());
            }
            else
            {
                // Mostrar error si no se encuentra el usuario
                await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}


