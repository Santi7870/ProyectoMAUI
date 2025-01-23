using Microsoft.Maui.Controls;

namespace ProyectoMAUI.Pages
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private void OnRegisterButtonPressed(object sender, EventArgs e)
        {
            var registerButton = sender as Button;
            if (registerButton != null)
            {
                registerButton.BackgroundColor = Color.FromArgb("#00ff26"); // Cambia a un color más claro
            }
        }

        private void OnRegisterButtonReleased(object sender, EventArgs e)
        {
            var registerButton = sender as Button;
            if (registerButton != null)
            {
                registerButton.BackgroundColor = Color.FromArgb("#FF4500"); // Vuelve al color original
            }
        }

        private void OnLoginButtonPressed(object sender, EventArgs e)
        {
            var loginButton = sender as Button;
            if (loginButton != null)
            {
                loginButton.BackgroundColor = Color.FromArgb("#651eff"); // Cambia a un color más claro
            }
        }

        private void OnLoginButtonReleased(object sender, EventArgs e)
        {
            var loginButton = sender as Button;
            if (loginButton != null)
            {
                loginButton.BackgroundColor = Color.FromArgb("#1E90FF"); // Vuelve al color original
            }
        }
    }
}
