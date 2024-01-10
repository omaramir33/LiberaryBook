using System.ComponentModel.DataAnnotations;

namespace LiberaryBook.Models
{
    public class LoginViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
