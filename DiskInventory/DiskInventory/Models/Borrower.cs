using System;
using System.Collections.Generic;

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
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string PhoneNum { get; set; }

        public virtual ICollection<DiscHasBorrower> DiscHasBorrowers { get; set; }
    }
}
