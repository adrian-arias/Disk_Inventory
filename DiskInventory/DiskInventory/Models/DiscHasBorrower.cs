using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class DiscHasBorrower
    {
        public int DiscHasBorrowerId { get; set; }
        [Required(ErrorMessage ="Please enter a borrowed date.")]
        public DateTime BorrowedDate { get; set; }
        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        [Required(ErrorMessage = "Please enter a borrower.")]
        public int BorrowerId { get; set; }
        [Required(ErrorMessage = "Please select a disc.")]
        public int DiscId { get; set; }

        public virtual Borrower Borrower { get; set; }
        public virtual Disc Disc { get; set; }
    }
}
