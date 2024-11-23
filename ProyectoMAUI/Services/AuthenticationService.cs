using SQLite;
using System;
using System.IO;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.Services
{
    public static class AuthenticationService
    {
        // Obtener la ruta de la base de datos
        private static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "usuarios.db3");

        public static async Task<bool> LogIn(string correo, string clave)
        {
            try
            {
                // Crear una conexión SQLite usando la ruta definida
                var db = new SQLiteConnection(DatabasePath);

                // Asegurarse de que la tabla existe
                db.CreateTable<Usuario>();

                // Buscar al usuario en la base de datos por correo y clave
                var usuario = db.Table<Usuario>().FirstOrDefault(u => u.Correo == correo && u.Clave == clave);

                if (usuario != null)
                {
                    // Si el usuario existe, se guarda en el servicio UserService
                    UserService.CurrentUser = usuario;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine($"Error al acceder a la base de datos: {ex.Message}");
                return false;
            }
        }
    }
}

