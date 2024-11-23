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
            _databaseService = new DatabaseService(dbPath);  // Pasamos la ruta como par�metro
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Validar que no haya campos vac�os
            if (string.IsNullOrEmpty(NombreEntry.Text) || string.IsNullOrEmpty(ApellidoEntry.Text) ||
                string.IsNullOrEmpty(EdadEntry.Text) || string.IsNullOrEmpty(CorreoEntry.Text) ||
                string.IsNullOrEmpty(ClaveEntry.Text))
            {
                await DisplayAlert("Error", "Por favor, complete todos los campos.", "OK");
                return;
            }

            // Validar que la edad sea un n�mero v�lido
            if (!int.TryParse(EdadEntry.Text, out int edad))
            {
                await DisplayAlert("Error", "La edad debe ser un n�mero v�lido.", "OK");
                return;
            }

            // Comprobar si el correo ya existe en la base de datos
            var existingUser = await _databaseService.GetUserAsync(CorreoEntry.Text);
            if (existingUser != null)
            {
                await DisplayAlert("Error", "Ya existe un usuario con ese correo.", "OK");
                return;
            }

            // Crear el usuario con los datos ingresados
            var usuario = new Usuario
            {
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                Edad = edad,
                Correo = CorreoEntry.Text,
                Clave = ClaveEntry.Text
            };

            // Registrar el nuevo usuario en la base de datos
            await _databaseService.AddUserAsync(usuario);
            await DisplayAlert("�xito", "Usuario registrado correctamente", "OK");

            // Redirigir a la p�gina de inicio de sesi�n
            await Navigation.PopAsync();  // O tambi�n puedes navegar a otra p�gina si lo prefieres
        }
    }
}



