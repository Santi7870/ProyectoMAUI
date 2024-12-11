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
            
            UserService.CurrentUser = null;
            UserService.CurrentUserName = null;

            
            Application.Current.MainPage = new NavigationPage(new WelcomePage());
        }

    }
}
