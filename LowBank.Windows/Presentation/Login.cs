using LowBank.Windows.Data;
using LowBank.Windows.Models;

namespace LowBank.Windows.Presentation
{
    public partial class Login : Form
    {
        private BaseCustomerRepository customerRepository;

        public Login()
        {
            InitializeComponent();
            customerRepository = new ApiCustomerRepository();

            //Caso seja necessario usar banco SQLite, descomentar linha abaixo
            //customerRepository = new SQLCustomerRepository();

            //Caso seja necessario usar arquivos CSV, descomentar linha abaixo
            //customerRepository = new FileCustomerRepository();
            customerRepository.LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Registration(this.customerRepository).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = long.Parse(textBox1.Text);
            var password = textBox2.Text;

            var loginmodel = new LoginModel(login, password);
            var isAutenticated = customerRepository.Login(loginmodel);

            if (isAutenticated)
            {
                var currentCustomer = customerRepository.GetCustomerOrDefault(login);
                var home = new Home(customerRepository, currentCustomer);
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Não foi possível fazer login", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
