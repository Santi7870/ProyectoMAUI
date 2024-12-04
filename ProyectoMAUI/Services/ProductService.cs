using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public class ProductService
{
    // URL de la API donde se enviarán los datos (actualiza esta URL a la de tu API)
    private readonly string ApiUrl = "http://localhost:5052/api/product";

    // Método para enviar los datos del producto a la API
    public async Task<bool> SendProductDataAsync(string productName, string description)
    {
        try
        {
            // Crear el objeto HttpClientHandler para personalizar la validación de certificados SSL
            var handler = new HttpClientHandler()
            {
                // Deshabilitar la validación del certificado SSL (solo para desarrollo)
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            // Crear una instancia de HttpClient utilizando el handler personalizado
            using (var client = new HttpClient(handler))
            {
                // Crear el contenido JSON para la solicitud POST
                var jsonContent = new StringContent(
                    $"{{\"name\": \"{productName}\", \"description\": \"{description}\"}}",
                    Encoding.UTF8,
                    "application/json"
                );

                // Realizar la solicitud POST a la API
                var response = await client.PostAsync(ApiUrl, jsonContent);

                // Verificar si la solicitud fue exitosa
                if (response.IsSuccessStatusCode)
                {
                    return true;  // Se enviaron los datos con éxito
                }
                else
                {
                    // Si la respuesta no es exitosa, manejar el error
                    return false;
                }
            }
        }
        catch (HttpRequestException ex)
        {
            // Capturar y mostrar cualquier error en la solicitud HTTP
            Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
            return false;
        }
    }
}

