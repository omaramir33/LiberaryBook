using System.ComponentModel.DataAnnotations;

namespace LiberaryBook.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public int Type { get; set; }

        public bool isActive { get; set; }

        public int IDNumber { get; set; }
    }
}
