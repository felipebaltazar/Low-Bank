using LowBank.Windows.Models;

namespace LowBank.Windows.Data
{
    public abstract class BaseCustomerRepository
    {
        public abstract void LoadData();

        public abstract Customer GetCustomerOrDefault(long account);

        public abstract bool Exists(long account);

        public abstract int Save(Customer customer);

        public abstract void Update(params Customer[] customer);

        public abstract bool Login(LoginModel loginModel);
    }
}
