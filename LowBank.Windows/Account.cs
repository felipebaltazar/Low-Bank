namespace LowBank.Windows
{
    internal class Account
    {
        private readonly int _id;
        private readonly string _name;
        private decimal amount;

        public int Id 
        { 
            get 
            {
                return _id; 
            } 
        }

        public decimal Amount
        {
            get
            {
                return amount;
            }
        }

        public Account(int id, string name, decimal amount)
        {
            this._id = id;
            this._name = name;
            this.amount = amount;
        }

        public static Account Parse(string texto)
        {
            string[] informacoes = texto.Split(',', 6);

            var conta = Convert.ToInt32(informacoes[0]);
            var nome = informacoes[1];
            var cpf = informacoes[2];
            var email = informacoes[3];
            var telefone = informacoes[4];

            var saldo = informacoes[5].ConvertDecimalString();

            // Transformar string em Account
            Account novaConta = new Account(conta, nome, saldo);

            return novaConta;
        }
    }
}
