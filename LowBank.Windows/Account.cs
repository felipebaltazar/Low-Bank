namespace LowBank.Windows
{
    internal class Account
    {
        //Numero da conta
        private readonly int _id;

        //Saldo
        private decimal _amount;

        public int Id 
        {
            get 
            {
                return _id; 
            }
        }

        public decimal Amount
        {
            get { return _amount; }
        }

        public Account(int id, decimal ammount)
        {
            _id = id;
            _amount = ammount;
        }
    }
}
