namespace Mod08.View;
using Mod08.ViewModel;
public partial class PaymentPage /*: ContentPage*/
{
    //private readonly UserViewModel _viewModel;
    public PaymentPage()
	{

		InitializeComponent();
        BindingContext = new UserViewModel();
        //_viewModel = new UserViewModel();
        //BindingContext = _viewModel;

        //// Load the ledger data
        //_viewModel.LoadLedgerCommand.Execute(null);
    }
}