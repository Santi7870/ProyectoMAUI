using ProyectoMAUI.Models;
using ProyectoMAUI.Services;

namespace ProyectoMAUI.Pages
{
    public partial class PurchaseHistoryPage : ContentPage
    {
        public List<Purchase> Purchases { get; set; }

        public PurchaseHistoryPage()
        {
            InitializeComponent();

            // Obtener las compras de la base de datos
            Purchases = PurchaseService.GetAllPurchases();

            BindingContext = this;
        }
    }
}
