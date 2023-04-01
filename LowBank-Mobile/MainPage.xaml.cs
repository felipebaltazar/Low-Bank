namespace LowBank_Mobile;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void LoginBtn_Clicked(object sender, EventArgs e)
    {

    }

    private async void SignBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("registrationpage");
    }
}

