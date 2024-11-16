using Microsoft.Maui.Controls;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly DatabaseService _databaseService = new();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var usuario = await _databaseService.IniciarSesionAsync(CorreoEntry.Text, ClaveEntry.Text);

            if (usuario != null)
            {
                await DisplayAlert("Bienvenido", $"Hola, {usuario.Nombre}", "OK");
            }
            else
            {
                await DisplayAlert("Error", "Correo o clave incorrectos", "OK");
            }
        }
    }
}
