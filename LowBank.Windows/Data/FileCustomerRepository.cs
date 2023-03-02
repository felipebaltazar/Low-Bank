using LowBank.Windows.Models;

namespace LowBank.Windows.Data
{
    public class FileCustomerRepository : BaseCustomerRepository
    {
        const string DATABASE_FILE_PATH = @"C:\Users\felip\source\Low-Bank\LowBank.Windows\Dados.csv";
        const string DATABASE_HEADER = "Numero Conta,Nome do cliente,CPF,Email,Telefone,Saldo";

        private List<Customer> clientes;

        public FileCustomerRepository()
        {
            clientes = new List<Customer>();
        }

        public override void LoadData()
        {
            CreateDatabase();

            string[] lines = File.ReadAllLines(DATABASE_FILE_PATH);

            for (int i = 1; i < lines.Length; i++)
            {
                Customer novoCliente = Customer.Parse(lines[i]);
                clientes.Add(novoCliente);
            }
        }

        public override Customer GetCustomerOrDefault(long identificationNumber)
        {
            return clientes.FirstOrDefault(c => c.CPF == identificationNumber || c.Account.Id == identificationNumber);
        }

        public override bool Exists(long CPF)
        {
            return clientes.Any(c => c.CPF == CPF);
        }

        public override int Save(Customer customer)
        {
            var novoNumeroConta = GetLastId() + 1;

            if (customer.Account == null)
            {
                Account newAccount = new Account(novoNumeroConta, 0, 0);
                customer.Account = newAccount;
            }

            string customerString = customer.ToString();
            File.AppendAllText(DATABASE_FILE_PATH, customerString);

            return customer.Account.Id;
        }

        public override void Update(params Customer[] customers)
        {
            foreach(Customer customer in customers)
            {
                int index = clientes.IndexOf(customer);
                clientes[index] = customer;
            }

            File.Delete(DATABASE_FILE_PATH);
            CreateDatabase();

            foreach(var cliente in clientes)
            {
                Save(cliente);
            }
        }

        public override bool Login(LoginModel loginModel)
        {
            return true;
        }

        private void CreateDatabase()
        {
            if (File.Exists(DATABASE_FILE_PATH))
                return;

            File.WriteAllText(DATABASE_FILE_PATH, DATABASE_HEADER);
        }

        private int GetLastId()
        {
            var ultimoId = 0;

            if (clientes.Count > 0)
            {
                var ultimoCliente = clientes.Last();
                ultimoId = ultimoCliente.Account.Id;
            }

            return ultimoId;
        }
    }
}
