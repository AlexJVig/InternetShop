using System;
namespace InternetShop.Models
{
    public class LoginResult
    {
        public bool LoginSucceeded
        {
            get;
            set;
        }
        public string Token
        {
            get;
            set;
        }

        public LoginResult()
        {
        }
    }
}
