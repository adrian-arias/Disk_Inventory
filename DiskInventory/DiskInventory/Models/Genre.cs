using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Genre
    {
        public Genre()
        {
            Discs = new HashSet<Disc>();
        }

        public int GenreId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disc> Discs { get; set; }
    }
}
