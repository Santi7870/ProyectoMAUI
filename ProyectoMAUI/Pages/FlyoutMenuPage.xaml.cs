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
                UserName = UserService.CurrentUser.Nombre;  // Aqu� usas el nombre del usuario
                UserEmail = UserService.CurrentUser.Correo; // Aqu� usas el correo del usuario
            }

            // Vinculamos las propiedades de la clase a la vista
            BindingContext = this;
        }

        private async void OnUserInfoButtonClicked(object sender, EventArgs e)
        {
            // Navegar a la p�gina de informaci�n del usuario
            await Navigation.PushAsync(new UserInfoPage());
        }
    }
}
