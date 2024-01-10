using System.ComponentModel.DataAnnotations;

namespace LiberaryBook.Models
{
    public class AddBookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int TotalInvetory { get; set; }

        [Required]
        public int BorrowedBook { get; set; }

        [Required]
        public int AvilableBook { get; set; }
    }
}
