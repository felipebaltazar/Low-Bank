using LowBank.Windows.Infrastructure;
using Newtonsoft.Json;
using SQLite;

namespace LowBank.Windows.Models
{
    public class Customer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [PrimaryKey]
        [JsonProperty("cpf")]
        public long CPF { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("telefone")]
        public long Telefone { get; set; }

        [Ignore]
        [JsonProperty("account")]
        public Account Account { get; set; }

        [Indexed]
        [JsonIgnore]
        public int AccountId { get; set; }

        public Customer(string name, string email, long cpf, long telefone, string password)
        {
            CPF = cpf;
            Name = name;
            Email = email;
            Telefone = telefone;
            Password = password;
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
            var customer = new Customer(nome, email, cpf, telefone, string.Empty);

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
