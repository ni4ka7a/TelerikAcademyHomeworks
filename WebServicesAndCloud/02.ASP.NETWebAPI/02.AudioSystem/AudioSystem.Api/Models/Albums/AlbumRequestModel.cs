namespace AudioSystem.Api.Models.Albums
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AlbumRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public byte PublishYear { get; set; }

        [MaxLength(30)]
        public string ProducerName { get; set; }

        [Required]
        public virtual ICollection<int> ArtistIds { get; set; }

        [Required]
        public virtual ICollection<int> SongIds { get; set; }
    }
}