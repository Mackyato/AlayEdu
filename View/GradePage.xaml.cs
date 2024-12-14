namespace Mod08.View;
using Mod08.ViewModel;
public partial class GradePage : ContentPage
{
	public GradePage()
	{
		InitializeComponent();
        BindingContext = new UserViewModel();
    }
}