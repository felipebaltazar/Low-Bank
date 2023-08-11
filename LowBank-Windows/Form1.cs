namespace LowBank_Windows
{
    public partial class Form1 : Form
    {
        private bool FazendoDragQueen;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (FazendoDragQueen)
            {
                this.Location = new Point(Location.X + e.X, Location.Y + e.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            FazendoDragQueen = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            FazendoDragQueen = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}