namespace LowBank.Windows.Models
{
    public class LoginModel
    {
        public long? Login { get; set; }

        public string Password { get; set; }

        public LoginModel(long? login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
