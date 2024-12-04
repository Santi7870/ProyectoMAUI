using System.Net.Http;
using System.Text;
using Microsoft.Maui.Controls;
using ProyectoMAUI.Models;
using System.Text.Json;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class PedidoPage : ContentPage
    {
        private const string ApiUrl = "http://localhost:5052/api/product"; // URL de tu API

        public PedidoPage()
        {
            InitializeComponent();
        }

        private async void OnSaveProductClicked(object sender, EventArgs e)
        {
            // Verifica si el usuario está autenticado
            if (UserService.CurrentUser == null)
            {
                await DisplayAlert("Error", "El usuario no está autenticado", "OK");
                return;
            }

            // Obtener nombre y apellido del usuario
            var userFirstName = UserService.CurrentUser?.Nombre ?? "Desconocido";
            var userLastName = UserService.CurrentUser?.Apellido ?? "Desconocido";

            // Crear el objeto Pedido
            var pedido = new Pedido
            {
                Name = ProductName.Text,          // Puedes seguir usando estos campos para el pedido
                Description = ProductDescription.Text,

                // Asignar nombre y apellido del usuario
                UserFirstName = userFirstName,
                UserLastName = userLastName
            };

            // Serializar el objeto Pedido a JSON
            var jsonContent = new StringContent(JsonSerializer.Serialize(pedido), Encoding.UTF8, "application/json");

            // Realizar la solicitud POST a la API
            using var client = new HttpClient();
            var response = await client.PostAsync(ApiUrl, jsonContent);

            // Verificar si la respuesta fue exitosa
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Éxito", "Pedido guardado exitosamente", "OK");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("Error", $"No se pudo guardar el pedido. Código: {response.StatusCode}, Detalle: {errorMessage}", "OK");
            }
        }
    }
}
