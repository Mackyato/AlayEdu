namespace Mod08.View;
using Mod08.ViewModel;
public partial class GradingSystem : ContentPage
{

    public GradingSystem()
	{
		InitializeComponent();
        BindingContext = new UserViewModel();
    }
    //private void OnAddGradeClicked(object sender, EventArgs e)
    //{
    //    if (_viewModel != null && SubjectPicker.SelectedIndex >= 0 && TermPicker.SelectedIndex >= 0 && RemarksPicker.SelectedIndex >= 0)
    //    {
    //        _viewModel.AddGrade(
    //            SubjectPicker.SelectedItem.ToString(),
    //            TermPicker.SelectedItem.ToString(),
    //            YearEntry.Text,
    //            double.TryParse(GradeEntry.Text, out var grade) ? grade : 0,
    //            RemarksPicker.SelectedItem.ToString()
    //        );

    //        // Clear input fields
    //        SubjectPicker.SelectedIndex = -1;
    //        TermPicker.SelectedIndex = -1;
    //        YearEntry.Text = string.Empty;
    //        GradeEntry.Text = string.Empty;
    //        RemarksPicker.SelectedIndex = -1;
    //    }
    //    else
    //    {
    //        DisplayAlert("Error", "Please fill all fields before adding a grade.", "OK");
    //    }
    //}
}