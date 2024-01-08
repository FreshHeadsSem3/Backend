using System.ComponentModel.DataAnnotations;

namespace FreshHeadBackend.Models
{
    public class LoginModel
    {
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public LoginModel(string userEmail, string userPassword)
        {
            UserEmail = userEmail;
            UserPassword = userPassword;
        }
    }
}
