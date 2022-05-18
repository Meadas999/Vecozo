using System.ComponentModel.DataAnnotations;

namespace VecozoWep.Models
{
    public class InlogVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }   
        [Required]
        public string Password { get; set; }
        public bool Retry { get; set; }

        public InlogVM(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public InlogVM()
        {

        }
    }
}
