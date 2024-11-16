namespace ProyectoMAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ProyectoMAUI.Pages.WelcomePage());
        }
    }
}
