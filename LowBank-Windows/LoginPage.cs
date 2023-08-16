using System.Linq;

namespace LowBank_Windows
{
    public partial class LoginPage : Form
    {
        private const string dbPath = "C:\\Users\\felip\\Downloads\\LowBankBancoDeDados.csv";

        private bool FazendoDrag;
        private Point startDragDropPosition = Point.Empty;

        public LoginPage()
        {
            InitializeComponent();
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

                //Acessar o arquivo, ler o texto
                string[] conteudoArquivo = File.ReadAllLines(dbPath);

                var clienteResultado = conteudoArquivo
                    .Skip(1)
                    .Select(l => Cliente.Parse(l))
                    .FirstOrDefault(c => c.CPF == cpfDaTela);

                if (clienteResultado == null)
                {
                    //Apresenta mensagem na tela
                    MessageBox.Show("Usuário não cadastrado");
                }
                else
                {
                    var homePage = new HomePage(clienteResultado);
                    homePage.Show();

                    Hide();
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
    }
}
