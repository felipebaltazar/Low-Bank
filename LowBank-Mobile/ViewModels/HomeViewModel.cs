namespace LowBank_Mobile.ViewModels
{
    internal class HomeViewModel : BaseViewModel, IQueryAttributable
    {
        private Customer _customer;

        public Customer Customer
        {
            get
            {
                return _customer;
            }
            set
            {
                _customer = value;
                NotifyPropertyChanged(nameof(Customer));
            }
        }

        public HomeViewModel()
        {
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query != null)
            {
                Customer = (Customer)query["customer"];
            }
        }
    }
}
