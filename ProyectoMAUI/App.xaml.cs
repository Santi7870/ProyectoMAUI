using ProyectoMAUI.Services;
using SQLite;
using System;
using Microsoft.Maui.Controls;
using ProyectoMAUI.Pages;

namespace ProyectoMAUI
{
    public partial class App : Application
    {
        static DatabaseService databaseService;

        public static DatabaseService Database
        {
            get
            {
                if (databaseService == null)
                {
                    // Ruta donde se almacenará la base de datos
                    var dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
                    databaseService = new DatabaseService(dbPath);
                }
                return databaseService;
            }
        }

        public App()
        {
            InitializeComponent();

            // Aquí puedes definir la página principal como LoginPage o cualquier otra
            MainPage = new NavigationPage(new WelcomePage());
        }
    }
}


