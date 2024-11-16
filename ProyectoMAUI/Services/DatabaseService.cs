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
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Usuario>().Wait();  // Asegúrate de que la tabla 'Usuario' esté creada
        }

        // Aquí van tus métodos para interactuar con la base de datos, como GetUserAsync
        public async Task<Usuario> GetUserAsync(string correo)
        {
            return await _database.Table<Usuario>().FirstOrDefaultAsync(u => u.Correo == correo);
        }

        public async Task<int> AddUserAsync(Usuario user)
        {
            return await _database.InsertAsync(user);
        }
    }
}



