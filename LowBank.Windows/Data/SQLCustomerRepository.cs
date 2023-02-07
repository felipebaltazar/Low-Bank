using LowBank.Windows.Models;
using SQLite;

namespace LowBank.Windows.Data
{
    public class SQLCustomerRepository : BaseCustomerRepository
    {
        readonly SQLiteConnection _connection;

        public SQLCustomerRepository()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LowBankData.db");
            _connection = new SQLiteConnection(databasePath);
        }

        public override void LoadData()
        {
            _connection.CreateTable<Customer>();
            _connection.CreateTable<Account>();
        }

        public override bool Exists(long accountId)
        {
            Customer customer = _connection.Find<Customer>(c => c.CPF == accountId || c.AccountId == accountId);

            return customer != null;
        }

        public override Customer GetCustomerOrDefault(long accountId)
        {
            Customer customer = _connection.Find<Customer>(c=> c.CPF == accountId || c.AccountId == accountId);

            if(customer != null)
            {
                customer.Account = _connection.Get<Account>(a => a.Id == customer.AccountId);
            }

            return customer;
        }

        public override void Update(params Customer[] customers)
        {
            //Atualiza clientes
            int customersAlterados = _connection.UpdateAll(customers);

            //Cria uma lista de sub-informações
            var accounts = customers.Select(c => c.Account);

            //Atualiza contas
            int contasAlteradas = _connection.UpdateAll(accounts);
        }

        public override int Save(Customer customer)
        {
            // Verifica se ja foi criada uma conta pro cliente
            if (customer.Account == null)
            {
                // Cria uma nova conta pro cliente
                customer.Account = new Account();
            }

            // Salva a conta do cliente no banco SQL
            _connection.Insert(customer.Account);

            // Faz a associação da conta no cliente (chave estrangeira)
            customer.AccountId = customer.Account.Id;

            // Salva o cliente com a informação da conta
            _connection.Insert(customer);

            return customer.AccountId;
        }
    }
}
