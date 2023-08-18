using LowBank_Windows.Data;

namespace LowBank_Windows
{
    public class CSVDataSource : BaseDataSource
    {
        private const string dbPath = "C:\\Users\\felip\\Downloads\\LowBankBancoDeDados.csv";

        public override void SalvarCliente(Cliente cliente)
        {
            //Salvar novo cliente no documento csv
            File.AppendAllText(dbPath, "\n" + cliente.ToString());
        }

        public override Cliente? GetClienteByCpf(string cpf)
        {
            //Acessar o arquivo, ler o texto
            string[] conteudoArquivo = File.ReadAllLines(dbPath);

            var clienteResultado = conteudoArquivo
                .Skip(1)
                .Select(l => Cliente.Parse(l))
                .FirstOrDefault(c => c.CPF == cpf);

            return clienteResultado;
        }
    }
}
