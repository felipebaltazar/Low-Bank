using LowBank.Windows.Data;
using LowBank.Windows.Models;

namespace LowBank.Windows.Presentation
{
    public partial class Transfer : Form
    {
        const char BACKSPACE_CHAR = '\b';

        private readonly CustomerRepository _customerRepository;
        private readonly Customer _customer;
        private Customer? destinyCustomer;

        public Transfer(Customer customer, CustomerRepository customerRepository)
        {
            _customer = customer;
            _customerRepository = customerRepository;
            InitializeComponent();

            destinyErrorLabel.Visible = false;
            FillFields();
        }

        private void DestinyAccountTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            button1.Enabled = false;
            destinyAmountTextbox.Text = string.Empty;
            destinyCpfTextbox.Text = string.Empty;
            destinyNameTextbox.Text = string.Empty;

            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != BACKSPACE_CHAR;
        }

        private void TransferButton_Click(object sender, EventArgs e)
        {
            if (destinyCustomer == null)
                return;

            if (!decimal.TryParse(transferAmountTextbox.Text, out var transferAmount))
                return;

            bool foiEfetuada = _customer.Account.Transfer(destinyCustomer.Account, transferAmount);

            if (foiEfetuada)
            {
                _customerRepository.Update(_customer, destinyCustomer);
                FillFields();
                FillDestinyFields();

                MessageBox.Show("Transferencia realizada com sucesso!");
                Close();
            }
            else
            {
                MessageBox.Show("Não rolou!", "Ops!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void DestinyAccountTextbox_TextChanged(object sender, EventArgs e)
        {
            if (!long.TryParse(destinyAccountTextbox.Text, out long accountNumber))
            {
                return;
            }

            destinyCustomer = _customerRepository.GetCustomerOrDefault(accountNumber);
            FillDestinyFields();
        }

        private void FillDestinyFields()
        {
            if (destinyCustomer != null)
            {
                destinyAmountTextbox.Text = $"R$ {destinyCustomer.Account.Amount}";
                destinyCpfTextbox.Text = destinyCustomer.CPF.ToString(@"000\.000\.000\-00");
                destinyNameTextbox.Text = destinyCustomer.Name;

                if (_customer.CPF == destinyCustomer.CPF)
                {
                    button1.Enabled = false;
                    destinyErrorLabel.Visible = true;
                }
                else
                {
                    destinyErrorLabel.Visible = false;
                    button1.Enabled = true;
                }
            }
        }

        private void FillFields()
        {
            nameTextBox.Text = _customer.Name;
            idTextBox.Text = _customer.Account.Id.ToString();
            cpfTextBox.Text = _customer.CPF.ToString(@"000\.000\.000\-00");
            amountTextBox.Text = $"R$ {_customer.Account.Amount}";
        }
    }
}
