using SQLite;
using ProyectoMAUI.Models;
using System.IO;
using System.Threading.Tasks;

namespace ProyectoMAUI.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "usuarios.db3");
            _database = new SQLiteAsyncConnection(databasePath);
            _database.CreateTableAsync<Usuario>().Wait();
        }

        public Task<int> RegistrarUsuarioAsync(Usuario usuario)
        {
            return _database.InsertAsync(usuario);
        }

        public Task<Usuario> IniciarSesionAsync(string correo, string clave)
        {
            return _database.Table<Usuario>().FirstOrDefaultAsync(u => u.Correo == correo && u.Clave == clave);
        }
    }
}

