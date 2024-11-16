using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
using Microsoft.Maui.Controls;

namespace ProyectoMAUI.Pages
{
    public partial class RegisterPage : ContentPage
    {
        private readonly DatabaseService _databaseService;

        public RegisterPage()
        {
            InitializeComponent();

            // Crear la instancia de DatabaseService con la ruta de la base de datos
            var dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            _databaseService = new DatabaseService(dbPath);  // Pasamos la ruta como parámetro
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NombreEntry.Text) || string.IsNullOrEmpty(ApellidoEntry.Text) ||
                string.IsNullOrEmpty(EdadEntry.Text) || string.IsNullOrEmpty(CorreoEntry.Text) ||
                string.IsNullOrEmpty(ClaveEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            var usuario = new Usuario
            {
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Edad = int.Parse(EdadEntry.Text),
                Correo = CorreoEntry.Text,
                Clave = ClaveEntry.Text
            };

            // Llamar al método para registrar el usuario
            await _databaseService.AddUserAsync(usuario);  // Suponiendo que tienes un método AddUserAsync para agregar usuarios
            await DisplayAlert("Éxito", "Usuario registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
    }
}


