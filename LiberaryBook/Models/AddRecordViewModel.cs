using System.ComponentModel.DataAnnotations;

namespace LiberaryBook.Models
{
    public class AddRecordViewModel
    {
        [Required]
        public int LiberaryID { get; set; }
        [Required]

        public int NoOfViolations { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateTime ReturnDeadLine { get; set; }

        [Required]
        public int ApproveReturnRequest { get; set; }
    }
}
