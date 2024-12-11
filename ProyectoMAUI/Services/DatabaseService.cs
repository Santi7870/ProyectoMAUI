using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoMAUI.Models;

namespace ProyectoMAUI.Services
{
    public class DatabaseService
    {
        
        readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            // Inicializa la conexión a la base de datos
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();  
        }

        // Método asincrónico para obtener el usuario por correo
        public async Task<Usuario> GetUserAsync(string correo)
        {
            // Usar SQLiteAsyncConnection para la consulta
            return await _database.Table<Usuario>().FirstOrDefaultAsync(u => u.Correo == correo);
        }

        // Método asincrónico para agregar un usuario
        public async Task<int> AddUserAsync(Usuario user)
        {
            return await _database.InsertAsync(user);
        }

        public async Task<int> UpdateUserAsync(Usuario user)
        {
            return await _database.UpdateAsync(user);
        }



    }
}




