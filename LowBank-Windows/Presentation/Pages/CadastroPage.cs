using LowBank_Windows.Data;
using System.Globalization;
using System.Text;

namespace LowBank_Windows
{
    public partial class CadastroPage : Form
    {
        private readonly BaseDataSource dataSource;

        public CadastroPage(BaseDataSource datasource)
        {
            InitializeComponent();
            dataSource = datasource;
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            //673.618.520-33
            var valorCampoTexto = cpfTextbox.Text;

            // Filtra caracteres numericos apenas
            var listaDeCaracteresNumericos = valorCampoTexto.Where(c => Char.IsDigit(c));

            // Concatena todos os caracteres transformando em uma string
            var cpf = string.Concat(listaDeCaracteresNumericos);
            //Equivalente inline
            //var cpf = string.Concat(cpfTextbox.Text.Where(c => Char.IsDigit(c)));

            if (nomeTextbox.Text == "")
            {
                MessageBox.Show("O campo \"Nome\" não pode ser vazio!");
                return;
            }

            if (cpf == "" || !cpf.IsCPF())
            {
                MessageBox.Show("O campo \"CPF\" está invalido!");
                return;
            }

            if (passwordTextbox.Text == "" || passwordTextbox.Text != passwordConfirmTextbox.Text)
            {
                MessageBox.Show("O campo \"Senha\" está invalido!");
                return;
            }

            var nome = nomeTextbox.Text;
            var senha = passwordTextbox.Text;
            var conta = Random.Shared.Next(1000, 9999);

            var senhaCriptografada = senha.Criptografa();
            var novoCliente = new Cliente(nome, cpf, conta.ToString(), 0, senhaCriptografada);

            dataSource.SalvarCliente(novoCliente);

            MessageBox.Show($"Conta {novoCliente.Conta} cadastrada com sucesso!");
            this.Close();
        }

        private void cpfTextbox_TextChanged(object sender, EventArgs e)
        {
            // Extrai os numeros do campo de texto de CPF
            var cpf = string.Concat(cpfTextbox.Text.Where(c => Char.IsDigit(c)));

            // Corta caso tenha mais de 11 digitos
            if (cpf.Length > 11)
            {
                cpf = cpf.Substring(0, 11);
            }

            // Inicia uma string para o texto mascarado
            StringBuilder textoMascardo = new StringBuilder();

            //Varre todos os caracteres do CPF
            for (int i = 0; i < cpf.Length; i++)
            {

                // Se for indice 3 ou 6
                // Insere um ponto antes do caracter
                if (i == 3 || i == 6)
                {
                    //0 1 2 . 3 4 5 . 6 7 8 - 9 10
                    textoMascardo.Append(".");
                }
                // Caso seja o index 9 insere o -
                else if (i == 9)
                {
                    textoMascardo.Append("-");
                }

                // Adiciona o caracter de fato
                textoMascardo.Append(cpf[i]);
            }

            // Cola o texto no campo de texto de CPF
            cpfTextbox.Text = textoMascardo.ToString();

            // Manda o cursor de texto pro ultimo 
            cpfTextbox.Select(cpfTextbox.Text.Length, 0);
        }
    }
}
