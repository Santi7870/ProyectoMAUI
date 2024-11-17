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

            // Validar si los campos no están vacíos
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor ingrese todos los campos.", "OK");
                return;
            }

            // Buscar usuario en la base de datos (suponiendo que App.Database.GetUserAsync() devuelve el usuario)
            var user = await App.Database.GetUserAsync(username);

            if (user != null && user.Clave == password)
            {
                // Iniciar sesión exitoso, guardar el nombre del usuario
                UserService.CurrentUserName = user.Nombre; // Guardar el nombre del usuario en el servicio

                // Navegar al catálogo después de la autenticación
                await Navigation.PushAsync(new CatalogPage());
            }
            else
            {
                // Mostrar error si no se encuentra el usuario o la contraseña es incorrecta
                await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}



