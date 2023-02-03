
namespace LowBank.Windows
{
    public partial class Form1 : Form
    {
        List<Account> accounts = new List<Account>();

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            string diretorio = @"C:\Users\felip\source\Low-Bank\LowBank.Windows\dados.csv";
            string[] linhas = File.ReadAllLines(diretorio);

            // Loop pra ler cada linha
            for (int i = 1; i < linhas.Length; i++)
            {
                string linhaAtual = linhas[i];

                // Adicionar nova conta na lista "accounts"
                accounts.Add(Account.Parse(linhaAtual));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroConta = accountTextbox.Text;

            int id = Convert.ToInt32(numeroConta);

            for (int i = 0; i < accounts.Count; i++)
            {
                Account contaAtual = accounts[i];
                
                if (contaAtual.Id == id)
                {
                    amountLabel.Text = "Saldo em conta: R$" + contaAtual.Amount;
                    break;
                }
            }
        }

        private void accountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            amountLabel.Text = string.Empty;


            char caracterPressionado = e.KeyChar;
            bool ehNumero = int.TryParse(caracterPressionado.ToString(), out int numeroConta);

            if (ehNumero || '\b' == caracterPressionado)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}