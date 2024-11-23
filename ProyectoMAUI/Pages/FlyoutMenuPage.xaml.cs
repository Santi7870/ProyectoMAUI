using ProyectoMAUI.Pages;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class FlyoutMenuPage : FlyoutPage


    {

        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public FlyoutMenuPage()
        {
            InitializeComponent();

            if (UserService.CurrentUser != null)
            {
                UserName = UserService.CurrentUser.Nombre;  // Aquí usas el nombre del usuario
                UserEmail = UserService.CurrentUser.Correo; // Aquí usas el correo del usuario
            }

            // Vinculamos las propiedades de la clase a la vista
            BindingContext = this;
        }

        private async void OnUserInfoButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la página de información del usuario
            await Navigation.PushAsync(new UserInfoPage());
        }
    }
}
