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

            switch (selectedColor)
            {
                case "Blanco":
                    Application.Current.MainPage.BackgroundColor = Colors.White;
                    break;
                case "Negro":
                    Application.Current.MainPage.BackgroundColor = Colors.Black;
                    break;
                case "Azul":
                    Application.Current.MainPage.BackgroundColor = Colors.Blue;
                    break;
                case "Verde":
                    Application.Current.MainPage.BackgroundColor = Colors.Green;
                    break;
                case "Rojo":
                    Application.Current.MainPage.BackgroundColor = Colors.Red;
                    break;
                default:
                    Application.Current.MainPage.BackgroundColor = Colors.White;
                    break;
            }
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
