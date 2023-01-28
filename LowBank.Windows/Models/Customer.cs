using LowBank.Windows.Infrastructure;

namespace LowBank.Windows.Models
{
    public class Customer
    {
        private readonly string _name;
        private readonly string _email;
        private readonly long _telefone;
        private readonly long _cpf;

        public string Name => _name;
        public string Email => _email;
        public long CPF => _cpf;
        public long Telefone => _telefone;

        public Account Account { get; set; }

        public Customer(string name, string email, long cpf, long telefone)
        {
            _name = name;
            _email = email;
            _cpf = cpf;
            _telefone = telefone;
        }

        internal static Customer Parse(string line)
        {
            string[] infos = line.Split(",", 6);

            //Criação do cliente
            string nome = infos[1];
            long cpf = Convert.ToInt64(infos[2]);
            string email = infos[3];
            long telefone = Convert.ToInt64(infos[4]);
            var customer = new Customer(nome, email, cpf, telefone);

            // Criação da conta
            int conta = Convert.ToInt32(infos[0]);
            string saldoString = infos[5].OnlyDecimalChars();
            decimal saldo = decimal.Parse(saldoString);
            customer.Account = new Account(conta, saldo);

            return customer;
        }

        public override string ToString()
        {
            string validCPF = CPF.ToString().PadLeft(11, '0');
            return $"\n{Account.Id},{Name},{validCPF},{Email},{Telefone},{Account.Amount}";
        }
    }
}
