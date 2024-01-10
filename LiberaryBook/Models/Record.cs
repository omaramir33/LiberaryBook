using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberaryBook.Models
{
    public class Record
    {
        [Key]

        public int Id { get; set; }
        public int LiberaryID { get; set; }
        public int NoOfViolations { get; set; }

        public int BookId { get; set; }
        public DateTime ReturnDeadLine { get; set; }
        public int ApproveReturnRequest { get; set; }
        public bool isActive { get; set; }

        public virtual Book Book { get; set; }


    }
}
