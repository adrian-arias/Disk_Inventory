using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Enter a Disc name!")]
        public string DiscName { get; set; }
        [Required(ErrorMessage = "Enter a Date!")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int GenreId { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public int DiscTypeId { get; set; }

        public virtual DiscType DiscType { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<DiscHasArtist> DiscHasArtists { get; set; }
        public virtual ICollection<DiscHasBorrower> DiscHasBorrowers { get; set; }
    }
}
