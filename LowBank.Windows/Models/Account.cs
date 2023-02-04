namespace LowBank.Windows.Models
{
    public class Account
    {
        //Numero da conta
        private readonly int _id;

        //Saldo
        private decimal _amount;

        private int _limit;

        public int Id
        {
            get
            {
                return _id;
            }
        }

        public int Limit => _limit;

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Account(int id, decimal amount, int limit)
        {
            _id = id;
            _amount = amount;
            _limit = limit;
        }

        public bool Transfer(Account destiny, decimal transferAmount)
        {
            if ((Amount + Limit) < transferAmount)
                return false;

            Amount -= transferAmount;
            destiny.Amount += transferAmount;
            return true;
        }
    }
}
