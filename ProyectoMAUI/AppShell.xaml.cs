using ProyectoMAUI.Pages;
using ProyectoMAUI.Services;

namespace ProyectoMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Limpiar la información del usuario actual
            UserService.CurrentUser = null;
            UserService.CurrentUserName = null;

            // Redirigir a la WelcomePage
            Application.Current.MainPage = new NavigationPage(new WelcomePage());
        }

    }
}
