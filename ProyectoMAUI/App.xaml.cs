using ProyectoMAUI.Services;
using ProyectoMAUI.Pages;
using Microsoft.Maui.Controls;
using System;

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
            MainPage = new SplashPage(); // Mostrar la página de carga al inicio

            // Iniciar la carga de la página principal
            LoadMainPageAsync();
        }

        private async void LoadMainPageAsync()
        {
            await Task.Delay(3000); // Simular un retraso para la página de carga

            // Verificar si el usuario ya ha iniciado sesión
            var userLoggedIn = UserService.CurrentUser != null;

            if (userLoggedIn)
            {
                // Si ya está autenticado, ir directamente a AppShell (con TabBar y Flyout)
                MainPage = new AppShell();
            }
            else
            {
                // Si no está autenticado, ir a la WelcomePage
                MainPage = new NavigationPage(new WelcomePage());
            }
        }
    }
}



