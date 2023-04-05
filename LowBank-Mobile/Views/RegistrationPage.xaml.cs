namespace LowBank_Mobile;

public partial class RegistrationPage : ContentPage
{
	private readonly ApiCustomerRepository _customerRepository;

	public RegistrationPage()
	{
		InitializeComponent();
        _customerRepository = new ApiCustomerRepository();
    }

    private async void SaveBtn_Clicked(object sender, EventArgs e)
    {
        var customer = new Customer();

        customer.Name = NameEntry.Text;
        customer.Email = EmailEntry.Text;
        customer.CPF = long.Parse(CpfEntry.Text);
        customer.Telefone = long.Parse(PhoneEntry.Text);
        customer.Password = PasswordEntry.Text;

        var numeroConta = _customerRepository.Save(customer);

        if (numeroConta == 0)
        {
            //Mostrar alerta de erro
            await this.DisplayAlert(
                "Erro",
                "não foi possivel criar sua conta",
                "Entendi!");
        }
        else
        {
            await this.DisplayAlert(
                "Sucesso",
                $"Conta criada: {numeroConta}",
                "Entendi!");

            //Mostrar alerta de sucesso
            await Shell.Current.GoToAsync("..");
        }
    }
}