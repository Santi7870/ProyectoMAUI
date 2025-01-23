using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace ProyectoMAUI.Pages
{
    public partial class SplashPage : ContentPage
    {
        public SplashPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000); // Simular carga de 3 segundos
            Application.Current.MainPage = new NavigationPage(new WelcomePage()); // Navegar a la página principal
        }
    }
}