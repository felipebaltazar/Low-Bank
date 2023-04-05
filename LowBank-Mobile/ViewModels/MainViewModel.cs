using System.Windows.Input;

namespace LowBank_Mobile.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly ApiCustomerRepository _customerRepository;

        public ICommand LoginCommand { get; set; }

        public ICommand NewAccountCommand { get; set; }

        private string login;

        public string Login {
            get
            {
                return login;
            }
            set
            {
                login = value;
                NotifyPropertyChanged(nameof(Login));
            }
        }

        private bool loginError;

        public bool LoginError
        {
            get
            {
                return loginError;
            }
            set
            {
                loginError = value;
                NotifyPropertyChanged(nameof(LoginError));
            }
        }

        private bool isBusy;

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                NotifyPropertyChanged(nameof(IsBusy));
            }
        }

        public string Password { get; set; }

        public MainViewModel()
        {
            _customerRepository = new ApiCustomerRepository();

            LoginCommand = new Command(()=>
            {
                IsBusy = true;
                _ = ExecuteLogin();
            });


            NewAccountCommand = new Command(()=>
            {
                IsBusy = true;
                _ = NewAccount();
            });
        }

        private async Task NewAccount()
        {
            await Shell.Current.GoToAsync("registrationpage");
            IsBusy = false;
        }

        private async Task ExecuteLogin()
        {
            var account = long.Parse(Login);
            var loginModel = new LoginModel(
                account,
                Password);

            var isLoginSuccess = _customerRepository.Login(loginModel);

            if (isLoginSuccess)
            {
                LoginError = false;
                var customer = _customerRepository.GetCustomerOrDefault(account);

                var parameters = new Dictionary<string, object>();
                parameters.Add("customer", customer);

                await Shell.Current.GoToAsync("homepage", parameters);
            }
            else
            {
                LoginError = true;
            }

            IsBusy = false;
        }
    }
}
