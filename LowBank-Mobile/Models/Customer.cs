using Newtonsoft.Json;

namespace LowBank_Mobile
{
    public class Customer
    {
        [JsonIgnore]
        public string Avatar { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("cpf")]
        public long CPF { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("telefone")]
        public long Telefone { get; set; }

        [JsonProperty("account")]
        public Account Account { get; set; }

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

        public override string ToString()
        {
            string validCPF = CPF.ToString().PadLeft(11, '0');
            return $"\n{Account.Id},{Name},{validCPF},{Email},{Telefone},{Account.Limit},{Account.Amount}";
        }
    }
}
