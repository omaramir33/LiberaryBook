namespace LiberaryBook.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int TotalInvetory { get; set; }

        public int BorrowedBook { get; set; }

        public int AvilableBook { get; set; }
    }
}
