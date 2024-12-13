using Mod08.ViewModel;
namespace Mod08.View;

public partial class GradePage : ContentPage
{
	public GradePage()
	{
		InitializeComponent();
        BindingContext = new UserViewModel();
    }
}