using ProyectoMAUI.Pages;

namespace ProyectoMAUI.Pages
{
    public partial class FlyoutMenuPage : FlyoutPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
        }

        private async void OnUserInfoButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la página de información del usuario
            await Navigation.PushAsync(new UserInfoPage());
        }
    }
}
