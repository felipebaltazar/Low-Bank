﻿using LowBank.Windows.Models;
using LowBank.Windows.Data;

namespace LowBank.Windows.Presentation
{
    public partial class Registration : Form
    {
        CustomerRepository customerRepository;

        public Registration(CustomerRepository repository)
        {
            customerRepository = repository;
            InitializeComponent();
            ResetErrorLabels();
        }

        private void newClientButton_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            isValid &= IsValid(nameTextBox.Text, nameErrorLabel);
            isValid &= IsValid(emailTextBox.Text, emailErrorLabel);
            isValid &= IsValid(phoneTextbox.Text, phoneErrorLabel);
            isValid &= IsValid(cpfTextBox.Text, cpfErrorLabel);

            if (!isValid)
                return;

            long cpf = Convert.ToInt64(cpfTextBox.Text);
            bool isDuplicado = customerRepository.Exists(cpf);
            if (isDuplicado)
            {
                MessageBox.Show(
                    $"Cpf {cpf:000\\.000\\.000\\-00} já cadastrado",
                    "Erro de cadastro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            long telefone = Convert.ToInt64(phoneTextbox.Text);
            Customer newCustomer = new Customer(nameTextBox.Text, emailTextBox.Text, cpf, telefone);
            int novoNumeroConta = customerRepository.Save(newCustomer);

            this.Close();

            MessageBox.Show($"Usuario conta {novoNumeroConta} cadastrado com sucesso!");
        }


        private bool IsValid(string text, Label errorLabel)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                errorLabel.Visible = true;
                return false;
            }

            return true;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ResetErrorLabels();
        }

        private void ResetErrorLabels()
        {
            nameErrorLabel.Visible = false;
            emailErrorLabel.Visible = false;
            cpfErrorLabel.Visible = false;
            phoneErrorLabel.Visible = false;
        }
    }
}