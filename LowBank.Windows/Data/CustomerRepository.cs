using LowBank.Windows.Models;

namespace LowBank.Windows.Data
{
    public class CustomerRepository
    {
        const string DATABASE_FILE_PATH = @"C:\Users\felip\source\Low-Bank\LowBank.Windows\Dados.csv";
        const string DATABASE_HEADER = "Numero Conta,Nome do cliente,CPF,Email,Telefone,Saldo";

        private List<Customer> clientes;

        public CustomerRepository()
        {
            clientes = new List<Customer>();
        }

        public void LoadData()
        {
            CreateDatabase();

            string[] lines = File.ReadAllLines(DATABASE_FILE_PATH);

            for (int i = 1; i < lines.Length; i++)
            {
                Customer novoCliente = Customer.Parse(lines[i]);
                clientes.Add(novoCliente);
            }
        }

        public Customer GetCustomerOrDefault(long identificationNumber)
        {
            return clientes.FirstOrDefault(c => c.CPF == identificationNumber || c.Account.Id == identificationNumber);
        }

        public bool Exists(long CPF)
        {
            return clientes.Any(c => c.CPF == CPF);
        }

        public int GetLastId()
        {
            var ultimoId = 0;

            if (clientes.Count > 0)
            {
                var ultimoCliente = clientes.Last();
                ultimoId = ultimoCliente.Account.Id;
            }

            return ultimoId;
        }

        public int Save(Customer customer)
        {
            var novoNumeroConta = GetLastId() + 1;

            Account newAccount = new Account(novoNumeroConta, 0);
            customer.Account = newAccount;

            string customerString = customer.ToString();
            File.AppendAllText(DATABASE_FILE_PATH, customerString);

            return customer.Account.Id;
        }

        private void CreateDatabase()
        {
            if (File.Exists(DATABASE_FILE_PATH))
                return;

            File.WriteAllText(DATABASE_FILE_PATH, DATABASE_HEADER);
        }
    }
}
