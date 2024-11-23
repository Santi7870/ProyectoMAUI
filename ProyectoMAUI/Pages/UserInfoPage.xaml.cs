using ProyectoMAUI.Models;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class UserInfoPage : ContentPage
    {
        public UserInfoPage()
        {
            InitializeComponent();

            // Establecer el BindingContext con el usuario actual
            BindingContext = UserService.CurrentUser;
        }

        private async void OnOpenFlyoutClicked(object sender, EventArgs e)
        {
            // Muestra el Flyout
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}
