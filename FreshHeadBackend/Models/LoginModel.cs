using System.ComponentModel.DataAnnotations;

namespace FlixnetBackend.Models
{
    public class LoginModel
    {
        [Key][Required] public Guid ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginModel(Guid id, string email, string password)
        {
            ID = id;
            Email = email;
            Password = password;
        }
    }
}
