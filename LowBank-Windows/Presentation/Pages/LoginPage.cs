using LowBank_Windows.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LowBank_Windows
{
    public partial class LoginPage : Form
    {
        private bool FazendoDrag;
        private Point startDragDropPosition = Point.Empty;

        private readonly BaseDataSource dataSource;

        public LoginPage(BaseDataSource dataSource)
        {
            InitializeComponent();

            this.dataSource = dataSource;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cpfTextbox.Visible == false)
            {
                avatarImage.Visible = false;
                cadastroButton.Visible = false;
                loginButton.Location = new Point(183, loginButton.Location.Y);

                cpfTextbox.Visible = true;
                passwordTextbox.Visible = true;
            }
            else
            {
                // recupera cpf digitado na tela
                string cpfDaTela = cpfTextbox.Text;

                var clienteResultado = dataSource.GetClienteByCpf(cpfDaTela);

                if (clienteResultado == null)
                {
                    //Apresenta mensagem na tela
                    MessageBox.Show("Usuário não cadastrado");
                }
                else
                {
                    var senhaCriptografada = passwordTextbox.Text.Criptografa();
                    if (clienteResultado.Password == senhaCriptografada)
                    {
                        var homePage = new HomePage(clienteResultado);
                        homePage.Show();

                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Senha inválida");
                    }
                }
            }
        }

        private void LoginPage_MouseDown(object sender, MouseEventArgs e)
        {
            FazendoDrag = true;
            startDragDropPosition = new Point(e.X, e.Y);
        }

        private void LoginPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (FazendoDrag)
            {
                Location = new Point(
                    Location.X + e.X - startDragDropPosition.X,
                    Location.Y + e.Y - startDragDropPosition.Y);
            }
        }

        private void LoginPage_MouseUp(object sender, MouseEventArgs e)
        {
            FazendoDrag = false;
            startDragDropPosition = Point.Empty;
        }

        private void LoginPage_DoubleClick(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void cadastroButton_Click(object sender, EventArgs e)
        {
            var cadastroPage = new CadastroPage(dataSource);
            cadastroPage.Show();

            cadastroPage.FormClosed += (s, e) => this.Show();

            this.Hide();
        }
    }
}
