namespace Mod08.View;
using Mod08.ViewModel;
using Mod08.Services;
public partial class LoginPage : ContentPage
{
    //private readonly LoginService _loginService;
    public LoginPage()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
    //private async void OnLoginButtonClicked(object sender, EventArgs e)
    //{
    //    // Get the username and password from the input fields
    //    string username = usernameEntry.Text;
    //    string password = passwordEntry.Text;

    //    // Validate that both fields are not empty
    //    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
    //    {
    //        await DisplayAlert("Error", "Please enter both username and password.", "OK");
    //        return;
    //    }

    //    // Simulate a login process
    //    if (username == "admin" && password == "1234") // Replace with actual login logic
    //    {
    //        await DisplayAlert("Success", "Login successful!", "OK");

    //        // Navigate to the UserPage
    //        await Shell.Current.GoToAsync("//UserPage");
    //    }
    //    else
    //    {
    //        await DisplayAlert("Error", "Invalid username or password.", "OK");
    //    }
    //}


}