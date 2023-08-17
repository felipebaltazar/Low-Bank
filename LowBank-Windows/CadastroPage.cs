namespace LowBank_Windows
{
    public partial class CadastroPage : Form
    {
        private const string dbPath = "C:\\Users\\felip\\Downloads\\LowBankBancoDeDados.csv";

        public CadastroPage()
        {
            InitializeComponent();
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            var nome = nomeTextbox.Text;
            var cpf = cpfTextbox.Text;
            var senha = passwordTextbox.Text;
            var conta = Random.Shared.Next(1000, 9999);

            var senhaCriptografada = senha.Criptografa();
            var novoCliente = new Cliente(nome, cpf, conta.ToString(), 0, senhaCriptografada);

            //Salvar novo cliente no documento csv
            File.AppendAllText(dbPath, "\n" + novoCliente.ToString());

            MessageBox.Show($"Conta {novoCliente.Conta} cadastrada com sucesso!");
            this.Close();
        }
    }
}
