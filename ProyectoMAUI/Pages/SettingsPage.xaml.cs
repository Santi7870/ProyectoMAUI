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

        // Cargar datos del usuario en los campos
        private void LoadUserData()
        {
            if (UserService.CurrentUser != null)
            {
                NombreEntry.Text = UserService.CurrentUser.Nombre;
                ApellidoEntry.Text = UserService.CurrentUser.Apellido;
                CorreoEntry.Text = UserService.CurrentUser.Correo;
                ClaveEntry.Text = UserService.CurrentUser.Clave;
            }
        }

        // Cambiar el color de fondo
        private void OnColorSelected(object sender, EventArgs e)
        {
            var selectedColor = ColorPicker.SelectedItem?.ToString();

            Color newColor = Colors.Black; // Color predeterminado (Negro)

            switch (selectedColor)
            {
                case "Negro":
                    newColor = Colors.Black;
                    break;
                case "Gris Oscuro":
                    newColor = Color.FromArgb("#2C2C2C");
                    break;
                case "Azul Marino":
                    newColor = Color.FromArgb("#1A1F71");
                    break;
                case "Vino":
                    newColor = Color.FromArgb("#4B1C25");
                    break;
                case "Verde Oscuro":
                    newColor = Color.FromArgb("#1B4D3E");
                    break;
            }

            // Actualizar el recurso global
            Application.Current.Resources["BackgroundColor"] = newColor;

            // Notificar al usuario
            DisplayAlert("Éxito", "El color de fondo ha sido actualizado.", "OK");
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
                await DisplayAlert("Éxito", "Para que se actualice a información del usuario, porfavor Cerrar la sesion.", "OK");
            }
        }
    }
}
