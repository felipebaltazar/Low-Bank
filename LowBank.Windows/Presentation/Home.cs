
using LowBank.Windows.Models;
using LowBank.Windows.Data;

namespace LowBank.Windows.Presentation
{
    public partial class Home : Form
    {
        //Representa o caracter de backspace
        const char BACKSPACE_CHAR = '\b';

        CustomerRepository customerRepository;

        public Home()
        {
            customerRepository = new CustomerRepository();
            InitializeComponent();
            customerRepository.LoadData();
        }

        private void AccountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            nameTextBox.Text = string.Empty;
            idTextBox.Text = string.Empty;
            cpfTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            amountTextBox.Text = string.Empty;
            phoneTextbox.Text = string.Empty;
            transferButton.Visible = false;

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

            Customer? cliente = customerRepository.GetCustomerOrDefault(accountNumber);

            if (cliente == null)
            {
                return;
            }

            nameTextBox.Text = cliente.Name;
            idTextBox.Text = cliente.Account.Id.ToString();
            cpfTextBox.Text = cliente.CPF.ToString(@"000\.000\.000\-00");
            emailTextBox.Text = cliente.Email;
            amountTextBox.Text = $"R$ {cliente.Account.Amount}";
            phoneTextbox.Text = string.Format(@"{0:+00(00)#####-####}", cliente.Telefone);
            transferButton.Visible = true;
        }

        private void newClientButton_Click(object sender, EventArgs e)
        {
            var registrationForm = new Registration(customerRepository);
            registrationForm.Show();

            registrationForm.FormClosed += (s, e) => customerRepository.LoadData();
        }
    }
}