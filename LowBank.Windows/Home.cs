
namespace LowBank.Windows
{
    public partial class Home : Form
    {
        //Representa o caracter de backspace
        const char BACKSPACE_CHAR = '\b';

        List<Customer> Clientes;

        public Home()
        {
            InitializeComponent();
            this.amountLabel.Text = string.Empty;
            this.userLabel.Text = string.Empty;

            LoadData();
        }


        private void LoadData()
        {
            Clientes = new List<Customer>();
            string[] lines = File.ReadAllLines(@"C:\Users\felip\source\Low-Bank\LowBank.Windows\Dados.csv");

            for (int i = 1; i < lines.Length; i++)
            {
                Customer novoCliente = Customer.Parse(lines[i]);
                Clientes.Add(novoCliente);
            }
        }

        private void AccountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            amountLabel.Text = string.Empty;
            userLabel.Text = string.Empty;

            if (sender is TextBoxBase campoDeTexto)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != BACKSPACE_CHAR;
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(accountTextbox.Text, out long accountNumber))
            {
                return;
            }

            Customer cliente = Clientes.FirstOrDefault(c => c.CPF == accountNumber || c.Account.Id == accountNumber);

            if (cliente == null)
            {
                return;
            }

            amountLabel.Text = "Valor em conta: " + cliente.Account.Amount;
            userLabel.Text = $"Bem vindo: {cliente.Name}\nEmail: {cliente.Email}\nCPF: {cliente.CPF}";

        }
    }
}