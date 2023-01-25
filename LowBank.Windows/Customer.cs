namespace LowBank.Windows
{
    internal class Customer
    {
        private readonly string _name;
        private readonly string _email;
        private readonly long _cpf;

        public string Name => _name;
        public string Email => _email;
        public long CPF => _cpf;

        public Account Account { get; set; }

        public Customer(string name, string email, long cpf)
        {
            _name = name;
            _email = email;
            _cpf = cpf;
        }

        internal static Customer Parse(string line)
        {
            string[] infos = line.Split(",", 6);

            //Criação do cliente
            string nome = infos[1];
            long cpf = Convert.ToInt64(infos[2]);
            string email = infos[3];
            var customer = new Customer(nome, email, cpf);

            // Criação da conta
            int conta = Convert.ToInt32(infos[0]);
            string saldoString = infos[5].OnlyDecimalChars();
            decimal saldo = decimal.Parse(saldoString);
            customer.Account = new Account(conta, saldo);

            return customer;
        }
    }
}
