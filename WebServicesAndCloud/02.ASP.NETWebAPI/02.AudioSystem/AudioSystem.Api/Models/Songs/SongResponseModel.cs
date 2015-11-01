namespace AudioSystem.Api.Models.Songs
{
    using AudioSystem.Models;

    public class SongResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public byte PublishYear { get; set; }

        public string Genre { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}