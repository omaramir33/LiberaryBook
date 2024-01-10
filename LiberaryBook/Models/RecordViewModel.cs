namespace LiberaryBook.Models
{
    public class RecordViewModel
    {
        public int Id { get; set; }
        public int LiberaryID { get; set; }
        public int NoOfViolations { get; set; }

        public int BookId { get; set; }
        public string ReturnDeadLine { get; set; }
        public int ApproveReturnRequest { get; set; }
    }
}
