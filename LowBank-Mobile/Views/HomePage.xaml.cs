using LowBank_Mobile.ViewModels;

namespace LowBank_Mobile;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomeViewModel();
	}
}