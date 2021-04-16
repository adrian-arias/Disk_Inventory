using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class DiscType
    {
        public DiscType()
        {
            Discs = new HashSet<Disc>();
        }

        public int DiscTypeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disc> Discs { get; set; }
    }
}
