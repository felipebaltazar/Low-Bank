using SQLite;

namespace LowBank_Windows.Data
{
    public class SQLiteDataSource : BaseDataSource
    {
        private readonly SQLiteConnection _connection;

        public SQLiteDataSource()
        {
            //C:\Users\{usuario}\Documents\
            var meusDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            //"C:\Users\{usuario}\Documents\" + "MyData.db";
            var databasePath = Path.Combine(meusDocumentos, "MyData.db");

            // Cria a conexao com o banco de dados
            _connection = new SQLiteConnection(databasePath);

            // Cria a tabela de clientes
            _connection.CreateTable<Cliente>();
        }

        public override Cliente GetClienteByCpf(string cpfDaTela)
        {
            var cliente = _connection.Find<Cliente>((cliente) => cliente.CPF == cpfDaTela);
            return cliente;
        }

        public override bool SalvarCliente(Cliente cliente)
        {
            var cpfNovoCliente = cliente.CPF;
            var clienteExistente = _connection.Find<Cliente>((cliente) => cliente.CPF == cpfNovoCliente);
            if(clienteExistente != null)
            {
                return false;
            }
            else
            {
                _connection.Insert(cliente);
                return true;
            }
        }
    }
}
