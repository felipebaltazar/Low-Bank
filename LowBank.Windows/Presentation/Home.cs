
using LowBank.Windows.Models;
using LowBank.Windows.Data;

namespace LowBank.Windows.Presentation
{
    public partial class Home : Form
    {
        //Representa o caracter de backspace
        const char BACKSPACE_CHAR = '\b';

        private BaseCustomerRepository customerRepository;
        private Customer currentCustomer;

        public Home(BaseCustomerRepository customerRepository, Customer currentCustomer)
        {
            this.currentCustomer = currentCustomer;
            this.customerRepository = customerRepository;
            InitializeComponent();
            LoadData();
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

        private void LoadData()
        {
            if (currentCustomer == null)
            {
                return;
            }

            nameTextBox.Text = currentCustomer.Name;
            idTextBox.Text = currentCustomer.Account.Id.ToString();
            cpfTextBox.Text = currentCustomer.CPF.ToString(@"000\.000\.000\-00");
            emailTextBox.Text = currentCustomer.Email;
            amountTextBox.Text = $"R$ {currentCustomer.Account.Amount}";
            phoneTextbox.Text = string.Format(@"{0:+00(00)#####-####}", currentCustomer.Telefone);
            transferButton.Visible = true;
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            var transferForm = new Transfer(currentCustomer, customerRepository);
            transferForm.Show();
        }
    }
}