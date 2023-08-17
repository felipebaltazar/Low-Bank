namespace LowBank_Windows
{
    public class Cliente
    {
        public string Nome;
        public string CPF;
        public string Conta;
        public decimal Saldo;
        public string Password;

        public Cliente(string nome, string cpf, string conta, decimal saldo, string password)
        {
            Nome = nome;
            CPF = cpf;
            Conta = conta;
            Saldo = saldo;
            Password = password;
        }

        public override string ToString()
        {
            return $"{CPF},{Conta},{Nome},{Saldo},{Password}";
            //return CPF + "," + Conta + "," + Nome + "," + Saldo + "," + Password;
        }

        public static Cliente Parse(string text)
        {
            // Quebrar informações por virgula
            string[] informacoes = text.Split(',');

            var cpf = informacoes[0];
            var conta = informacoes[1];
            var nome = informacoes[2];
            var saldo = informacoes[3];
            var senha = informacoes[4];

            decimal saldoDecimal = decimal.Parse(saldo);

            return new Cliente(nome, cpf, conta, saldoDecimal, senha);
        }
    }
}
