using ProyectoMAUI.Models;
using ProyectoMAUI.Services;
using Microsoft.Maui.Controls;
using System;
using System.IO;

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
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;

            // Validaci�n de campos
            if (string.IsNullOrEmpty(username))
            {
                await DisplayAlert("Error", "Por favor ingrese el correo electr�nico.", "OK");
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Por favor ingrese la contrase�a.", "OK");
                return;
            }

            // Ruta correcta de la base de datos
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            var databaseService = new DatabaseService(dbPath);

            // Buscar el usuario por correo (o nombre de usuario si usas un campo diferente)
            var user = await databaseService.GetUserAsync(username);

            // Verificar si el usuario existe y la contrase�a es correcta
            if (user != null && user.Clave == password)
            {
                // Iniciar sesi�n exitoso, guardar el usuario completo en el servicio
                UserService.CurrentUser = user; // Guardamos el usuario actual
                UserService.CurrentUserName = user.Nombre; // Asignamos el nombre del usuario a CurrentUserName

                // Navegar a AppShell despu�s del inicio de sesi�n
                Application.Current.MainPage = new AppShell(); // Cambiar a AppShell con Flyout y TabBar
            }
            else
            {
                await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }
    }
}








