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

        public List<Customer> Contacts
        {
            get;
            set;
        }

        public HomeViewModel()
        {
            Contacts = new List<Customer>()
            {
                new Customer()
                {
                    Avatar = "profile1.png",
                    Name = "Cristian",
                    CPF = 123456789,
                    Account = new Account()
                    {
                        Id = 1002,
                    },
                },

                new Customer()
                {
                    Avatar = "profile2.png",
                    Name = "Guilherme",
                    CPF = 4564564,
                    Account = new Account()
                    {
                        Id = 1001,
                    },
                },

                new Customer()
                {
                    Avatar = "profile1.png",
                    Name = "Felipe",
                    CPF = 83380106003,
                    Account = new Account()
                    {
                        Id = 1003,
                    },
                },
            };
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
