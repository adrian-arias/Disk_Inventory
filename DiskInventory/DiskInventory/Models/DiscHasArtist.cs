using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class DiscHasArtist
    {
        public int DiscHasArtistId { get; set; }
        public int DiscId { get; set; }
        public int ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Disc Disc { get; set; }
    }
}
