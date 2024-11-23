using Microsoft.Maui.Controls;
using ProyectoMAUI.Services;
using ProyectoMAUI.Models;
using System;
using System.IO;

namespace ProyectoMAUI.Pages
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            LoadUserData(); // Cargar la información del usuario actual
        }

        private async void OnOpenFlyoutClicked(object sender, EventArgs e)
        {
            // Muestra el Flyout
            Shell.Current.FlyoutIsPresented = true;
        }

        // Cargar datos del usuario en los campos
        private void LoadUserData()
        {
            if (UserService.CurrentUser != null)
            {
                NombreEntry.Text = UserService.CurrentUser.Nombre;
                ApellidoEntry.Text = UserService.CurrentUser.Apellido;
                CorreoEntry.Text = UserService.CurrentUser.Correo;
                ClaveEntry.Text = UserService.CurrentUser.Clave;
                // Asignar el color de fondo actual al recurso de color global
                Application.Current.Resources["BackgroundColor"] = Color.FromArgb(UserService.CurrentUser.BackgroundColor);
            }
        }

        // Cambiar el color de fondo
        private async void OnColorSelected(object sender, EventArgs e)
        {
            var selectedColor = ColorPicker.SelectedItem?.ToString();

            string newColorHex = "#000000"; // Negro por defecto

            switch (selectedColor)
            {
                case "Negro":
                    newColorHex = "#000000";
                    break;
                case "Gris Oscuro":
                    newColorHex = "#2C2C2C";
                    break;
                case "Azul Marino":
                    newColorHex = "#1A1F71";
                    break;
                case "Vino":
                    newColorHex = "#4B1C25";
                    break;
                case "Verde Oscuro":
                    newColorHex = "#1B4D3E";
                    break;
            }

            // Actualizar el color del usuario en la base de datos
            var currentUser = UserService.CurrentUser;
            if (currentUser != null)
            {
                currentUser.BackgroundColor = newColorHex;
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
                var databaseService = new DatabaseService(dbPath);
                await databaseService.UpdateUserAsync(currentUser); // Método para guardar cambios
            }

            // Aplicar el color a la aplicación
            Application.Current.Resources["BackgroundColor"] = Color.FromArgb(newColorHex);

            await DisplayAlert("Éxito", "El color de fondo ha sido actualizado.", "OK");
        }

        // Guardar cambios en los datos del usuario
        private async void OnSaveChangesClicked(object sender, EventArgs e)
        {
            // Validar los datos ingresados
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(ApellidoEntry.Text) ||
                string.IsNullOrWhiteSpace(CorreoEntry.Text) ||
                string.IsNullOrWhiteSpace(ClaveEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            // Actualizar los datos del usuario
            var user = UserService.CurrentUser;
            if (user != null)
            {
                user.Nombre = NombreEntry.Text;
                user.Apellido = ApellidoEntry.Text;
                user.Correo = CorreoEntry.Text;
                user.Clave = ClaveEntry.Text;

                // Guardar los cambios en la base de datos
                var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
                var databaseService = new DatabaseService(dbPath);

                await databaseService.UpdateUserAsync(user);
                await DisplayAlert("Éxito", "Para que se actualice la información del usuario, por favor cierre la sesión.", "OK");
            }
        }
    }
}

