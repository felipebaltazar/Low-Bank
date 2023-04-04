namespace LowBank_Mobile;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute("registrationpage", typeof(RegistrationPage));
        Routing.RegisterRoute("homepage", typeof(HomePage));
    }
}
