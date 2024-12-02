namespace Mod08.View;
using Mod08.ViewModel;
using Mod08.Services;
public partial class LoginPage : ContentPage
{
    //private readonly LoginService _loginService;
    public LoginPage()
	{
		InitializeComponent();
    }
    private async void OnNavigateToUserPageClicked(object sender, EventArgs e)
    {
        // Navigate to the UserPage using its route
        await Shell.Current.GoToAsync("//UserPage");
    }


}