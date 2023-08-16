namespace LowBank_Windows
{
    public partial class HomePage : Form
    {
        private bool FazendoDragQueen;
        private Point startDragDropPosition = Point.Empty;

        private Cliente usuarioLogado;

        public HomePage(Cliente cliente)
        {
            usuarioLogado = cliente;
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (FazendoDragQueen)
            {
                Location = new Point(
                    Location.X + e.X - startDragDropPosition.X,
                    Location.Y + e.Y - startDragDropPosition.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            FazendoDragQueen = true;
            startDragDropPosition = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            FazendoDragQueen = false;
            startDragDropPosition = Point.Empty;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            FazendoDragQueen = true;
            startDragDropPosition = new Point(e.X, e.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Atribuir o nome no Label do formulario
            textoBemVindo.Text = "Bem Vindo, " + usuarioLogado.Nome + "!";

            // Atribuir o Saldo no label do cartao
            saldoTexto.Text = "R$ " + usuarioLogado.Saldo.ToString("n2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarioLogado.Saldo += 10;
            saldoTexto.Text = "R$ " + usuarioLogado.Saldo.ToString("n2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuarioLogado.Saldo -= 10;
            saldoTexto.Text = "R$ " + usuarioLogado.Saldo.ToString("n2");
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void Form1_DoubleClick(object sender, MouseEventArgs e)
        {
            this.CenterToScreen();
        }
    }
}