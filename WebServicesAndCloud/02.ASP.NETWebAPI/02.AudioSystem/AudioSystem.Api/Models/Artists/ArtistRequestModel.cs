namespace AudioSystem.Api.Models.Artists
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ArtistRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int CountryId { get; set; }

        public virtual ICollection<int> AlbumIds { get; set; }

        public virtual ICollection<int> SongIds { get; set; }
    }
}