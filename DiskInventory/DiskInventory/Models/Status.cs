using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Status
    {
        public Status()
        {
            Discs = new HashSet<Disc>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disc> Discs { get; set; }
    }
}
