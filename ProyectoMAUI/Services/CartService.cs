using ProyectoMAUI.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace ProyectoMAUI.Services
{
    public static class CartService
    {
        private static readonly List<CartItem> CartItems = new List<CartItem>();
        private const string CartFileName = "carrito.json"; // Nombre del archivo JSON

        // Agregar un producto al carrito
        public static void AddToCart(CartItem item)
        {
            CartItems.Add(item);
            SaveCartAsync(); // Guardar el carrito después de añadir un producto
        }

        // Obtener los productos del carrito
        public static List<CartItem> GetCartItems()
        {
            return CartItems;
        }

        // Obtener el total del carrito
        public static double GetCartTotal()
        {
            return CartItems.Sum(item => item.Total); // Usa el Total (Precio * Cantidad)
        }

        // Limpiar el carrito
        public static void ClearCart()
        {
            CartItems.Clear();
            SaveCartAsync(); // Guardar después de limpiar el carrito
        }

        // Eliminar un artículo del carrito
        public static void RemoveItem(CartItem item)
        {
            CartItems.Remove(item);
            SaveCartAsync(); // Guardar después de eliminar un producto
        }

        // Guardar el carrito en un archivo JSON
        private static async void SaveCartAsync()
        {
            var json = JsonSerializer.Serialize(CartItems);
            var filePath = Path.Combine(FileSystem.AppDataDirectory, CartFileName);

            // Escribir el JSON en el archivo
            await File.WriteAllTextAsync(filePath, json);
        }

        // Cargar el carrito desde un archivo JSON
        public static async Task LoadCartAsync()
        {
            var filePath = Path.Combine(FileSystem.AppDataDirectory, CartFileName);

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                var items = JsonSerializer.Deserialize<List<CartItem>>(json);

                // Cargar los elementos al carrito si el archivo existe
                if (items != null)
                {
                    CartItems.Clear();
                    CartItems.AddRange(items);
                }
            }
        }
    }
}



