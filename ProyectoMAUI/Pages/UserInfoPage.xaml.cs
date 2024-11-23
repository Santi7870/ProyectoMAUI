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
    }
}
