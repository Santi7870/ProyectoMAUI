namespace ProyectoMAUI.Pages;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    private async void OnOpenFlyoutClicked(object sender, EventArgs e)
    {
        // Muestra el Flyout
        Shell.Current.FlyoutIsPresented = true;
    }
}