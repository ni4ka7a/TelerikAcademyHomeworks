namespace AudioSystem.Api.Models.Songs
{
    using System.ComponentModel.DataAnnotations;

    public class SongRequestModel
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        public byte PublishYear { get; set; }

        [Required]
        [MaxLength(15)]
        public string Genre { get; set; }

        public int ArtistId { get; set; }

        public int AlbumId { get; set; }
    }
}