using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Artist
    {
        public Artist()
        {
            DiscHasArtists = new HashSet<DiscHasArtist>();
        }

        public int ArtistId { get; set; }
        [Required(ErrorMessage = "Enter a first name!")]
        public string Fname { get; set; }
        public string Lname { get; set; }
        [Required]
        public int ArtistTypeId { get; set; }
       
        public virtual ArtistType ArtistType { get; set; }
        public virtual ICollection<DiscHasArtist> DiscHasArtists { get; set; }
    }
}
