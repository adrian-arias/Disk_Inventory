using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Borrower
    {
        public Borrower()
        {
            DiscHasBorrowers = new HashSet<DiscHasBorrower>();
        }

        public int BorrowerId { get; set; }
        [Required(ErrorMessage = "Enter a first name!")]
        public string Fname { get; set; }
        [Required(ErrorMessage = "Enter a last name!")]
        public string Lname { get; set; }
        [Required(ErrorMessage = "Enter a number in the following format: XXX-XXX-XXXX!")]
        public string PhoneNum { get; set; }

        public virtual ICollection<DiscHasBorrower> DiscHasBorrowers { get; set; }
    }
}
