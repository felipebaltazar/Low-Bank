using LowBank.Windows.Infrastructure;
using SQLite;

namespace LowBank.Windows.Models
{
    public class Customer
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [PrimaryKey]
        public long CPF { get; set; }

        public long Telefone { get; set; }

        [Ignore]
        public Account Account { get; set; }

        [Indexed]
        public int AccountId { get; set; }

        public Customer(string name, string email, long cpf, long telefone)
        {
            CPF = cpf;
            Name = name;
            Email = email;
            Telefone = telefone;
        }

        public Customer()
        {
        }

        internal static Customer Parse(string line)
        {
            string[] infos = line.Split(",", 7);

            //Criação do cliente
            string nome = infos[1];
            long cpf = Convert.ToInt64(infos[2]);
            string email = infos[3];
            long telefone = Convert.ToInt64(infos[4]);
            var customer = new Customer(nome, email, cpf, telefone);

            // Criação da conta
            int conta = Convert.ToInt32(infos[0]);

            string limitString = infos[5].OnlyDecimalChars();
            int limit = int.Parse(limitString);

            string saldoString = infos[6].OnlyDecimalChars();
            decimal saldo = decimal.Parse(saldoString);

            customer.Account = new Account(conta, saldo, limit);

            return customer;
        }

        public override string ToString()
        {
            string validCPF = CPF.ToString().PadLeft(11, '0');
            return $"\n{Account.Id},{Name},{validCPF},{Email},{Telefone},{Account.Limit},{Account.Amount}";
        }
    }
}
