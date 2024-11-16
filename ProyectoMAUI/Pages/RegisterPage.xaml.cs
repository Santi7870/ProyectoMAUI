using Microsoft.Maui.Controls;
using ProyectoMAUI.Models;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class RegisterPage : ContentPage
    {
        private readonly DatabaseService _databaseService = new();

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var usuario = new Usuario
            {
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Edad = int.Parse(EdadEntry.Text),
                Correo = CorreoEntry.Text,
                Clave = ClaveEntry.Text
            };

            await _databaseService.RegistrarUsuarioAsync(usuario);
            await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
    }
}
