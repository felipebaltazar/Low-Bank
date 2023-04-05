using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowBank_Mobile
{
    public class Account
    {
        public int Id { get; set; }

        public int Limit { get; set; }

        public decimal Amount { get; set; }

        public Account(int id, decimal amount, int limit)
        {
            Id = id;
            Amount = amount;
            Limit = limit;
        }

        public Account()
        {
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
