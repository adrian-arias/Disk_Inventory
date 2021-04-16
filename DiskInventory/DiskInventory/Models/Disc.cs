using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Disc
    {
        public Disc()
        {
            DiscHasArtists = new HashSet<DiscHasArtist>();
            DiscHasBorrowers = new HashSet<DiscHasBorrower>();
        }

        public int DiscId { get; set; }
        public string DiscName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public int StatusId { get; set; }
        public int DiscTypeId { get; set; }

        public virtual DiscType DiscType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<DiscHasArtist> DiscHasArtists { get; set; }
        public virtual ICollection<DiscHasBorrower> DiscHasBorrowers { get; set; }
    }
}
