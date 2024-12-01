namespace Mod08.View;
using Mod08.ViewModel;


public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();
		BindingContext = new UserViewModel();
	}
    //private void OnCourseSelected(object sender, EventArgs e)
    //{
    //    var picker = (Picker)sender;
    //    var selectedCourse = picker.SelectedItem as string;

    //    // Filter users based on selected course (for example)
    //    if (!string.IsNullOrEmpty(selectedCourse))
    //    {
    //        // You can implement logic to load students for the selected course here
    //        // Example: Filter users by selected course
    //        var viewModel = (UserViewModel)BindingContext;
    //        viewModel.LoadUsersByCourse(selectedCourse);
    //    }
    //}
}