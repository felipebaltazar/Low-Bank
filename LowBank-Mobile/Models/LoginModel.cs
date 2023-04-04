using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowBank_Mobile
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
